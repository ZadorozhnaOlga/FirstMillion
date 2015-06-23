using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.IO;

namespace FirstMillion_new.App_Code
{
    public class XmlQuestionRepository : IQuestionRepository
    {
        #region Fields

        private readonly string _fileName;

        #endregion


        #region Constructors

        public XmlQuestionRepository(string fileName)
        {
            _fileName = fileName;
        }

        #endregion


        #region IQuestionRepository

        public IEnumerable<Question> GetQuestions()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Question[]));

            using (FileStream fs = new FileStream(_fileName, FileMode.OpenOrCreate))
            {
                return (IEnumerable<Question>)formatter.Deserialize(fs);
            }
        }

        #endregion
    }
}