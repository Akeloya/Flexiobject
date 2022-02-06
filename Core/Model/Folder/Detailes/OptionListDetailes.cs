using CoaApp.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CoaApp.Core
{
    ///<inheritdoc/>
    public abstract class OptionListDetailes: AppBase, IOptionListDetailes
    {
        private IList<OptionListValue> _list = new List<OptionListValue>();
        /// <include file='commonDocs.xml' path='docs/members[@name="constructors"]/defaultProtected/*'/>
        protected OptionListDetailes(IApplication app, object parent) : base(app, parent)
        {

        }
        ///<inheritdoc/>
        public IOptionListValue this[int idx] => _list[idx];
        ///<inheritdoc/>
        public IOptionListValue this[string alias] => _list.SingleOrDefault(x=> x.Alias == alias);
        ///<inheritdoc/>
        public int Count => _list.Count;
        ///<inheritdoc/>
        public IOptionListValue DefaultValue { get ; set ; }
        ///<inheritdoc/>
        public IOptionListValue Highest => _list.SingleOrDefault(x => x.Position == _list.Max(y => y.Position));
        ///<inheritdoc/>
        public IOptionListValue Lowest => _list.SingleOrDefault(x => x.Position == _list.Min(y => y.Position));
        ///<inheritdoc/>
        public abstract IOptionListValue Create();
        ///<inheritdoc/>
        public void InsertAt(IOptionListValue val, int idx)
        {
            var inserting = (OptionListValue)val;
            if (idx < _list.Count)
            {
                //Ставим в начало или где-то между элементами.
                if (idx <= 0)
                    inserting.Position = (Highest?.Position ?? 0) + 1;
                else
                    inserting.Position = this[idx].Position;
                for (var i = idx; i > 0; i--)
                {
                    _list[i].Position++;
                }
            }
            else
            {
                inserting.Position = (Lowest?.Position ?? 0) + 1;
                for (var i = 0; i < _list.Count; i++)
                    _list[i].Position++;
            }
            _list.Add(inserting);
            _list = _list.OrderByDescending(x => x.Position).ToList();
        }
        ///<inheritdoc/>
        public void Remove(int idx)
        {
            if (idx < _list.Count && idx > 0)
                _list.RemoveAt(idx);
        }
        ///<inheritdoc/>
        public void Swap(int idx1, int idx2)
        {
            if (idx1 < 0 || idx1 >= _list.Count || idx2 < 0 || idx2 >= _list.Count)
                return;
            var item1 = _list[idx1];
            var item2 = _list[idx2];
            item1.Position = item2.Position + item1.Position;
            item2.Position = item1.Position - item2.Position;
            item1.Position = item1.Position - item2.Position;
            _list = _list.OrderByDescending(x => x.Position).ToList();
        }
    }
}
