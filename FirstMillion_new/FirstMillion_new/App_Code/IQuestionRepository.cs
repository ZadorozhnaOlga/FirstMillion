using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstMillion_new.App_Code
{
    public interface IQuestionRepository
    {
        IEnumerable<Question> GetQuestions();
    }
}
