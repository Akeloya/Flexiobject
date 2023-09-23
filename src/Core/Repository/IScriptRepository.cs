using FlexiObject.Core.Interfaces;

namespace FlexiObject.Core.Repository
{
    internal interface IScriptRepository
    {
        public IScript GetScript(string scriptName);
        public void SaveScript(IScript script);
    }
}
