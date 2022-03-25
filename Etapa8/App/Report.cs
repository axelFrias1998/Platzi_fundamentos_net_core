using System;
using System.Collections.Generic;
using System.Linq;
using Etapa8.Entities;

namespace Etapa8.App
{
    public class Report
    {
        Dictionary<Keys, IEnumerable<BaseObject>> _dictionary;

        public Report(Dictionary<Keys, IEnumerable<BaseObject>> dictionary)
        {
            if(dictionary is null)
                throw new ArgumentNullException(nameof(dictionary));
            _dictionary = dictionary;
        }

        public IEnumerable<School> GetSchoolList()
        {
            //var list = _dictionary.GetValueOrDefault(Keys.School);
            if(_dictionary.TryGetValue(Keys.School, out IEnumerable<BaseObject> result))
                return result.Cast<School>();
            else
                return null;
        }

        public IEnumerable<Evaluation> GetEvaluationsList()
        {
            if(_dictionary.TryGetValue(Keys.Evaluations, out IEnumerable<BaseObject> result))
                return result.Cast<Evaluation>();
            else
                return null;
        }

        public IEnumerable<string> GetClassesList()
        {
           return GetClassesList(out var dummy);
        }

        public IEnumerable<string> GetClassesList(out IEnumerable<Evaluation> evaluations)
        {
            evaluations = GetEvaluationsList();
            return (from Evaluation evaluation in evaluations
                    select evaluation.Class.Name).Distinct();
        }

        public Dictionary<string, IEnumerable<Evaluation>> GetEvaluationDictionaryByClass()
        {
            var dictionaryResult = new Dictionary<string, IEnumerable<Evaluation>>();
            
            var classes = GetClassesList(out var evaluations);

            foreach (var cl in classes)
            {
                var evals = from e in evaluations
                            where e.Class.Name.Equals(cl)
                            select e;
                dictionaryResult.Add(cl, evals);
            }
            
            return dictionaryResult;
        }

        public Dictionary<string, IEnumerable<object>> GetAverageEvaluationByClass()
        {
            var result = new Dictionary<string, IEnumerable<object>>();
            var dictEvaluationByClass = GetEvaluationDictionaryByClass();

            foreach (var item in dictEvaluationByClass)
            {
                var averageStudent = from evaluation in item.Value
                            group evaluation by new { 
                                evaluation.Student.Id,
                                evaluation.Student.Name
                            }
                            into groupEvaluationsStudent
                            select new Average{ 
                                StudentId = groupEvaluationsStudent.Key.Id,
                                StudentName = groupEvaluationsStudent.Key.Name,
                                AverageEvaluation = groupEvaluationsStudent.Average(x => x.Score)
                            };
                result.Add(item.Key, averageStudent);
            }
            
            return result;
        }

    }
}