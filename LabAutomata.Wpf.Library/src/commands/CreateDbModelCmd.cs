using LabAutomata.Db.models;
using LabAutomata.Db.repository;
using LabAutomata.Wpf.Library.adapter;
using LabAutomata.Wpf.Library.common;
using LabAutomata.Wpf.Library.models;
using System.Windows.Threading;

namespace LabAutomata.Wpf.Library.commands {
    public abstract class CreateDbModelCmd<TDomain, TModel> : CommandAsync
                                            where TDomain : DomainModel<TModel>
                                            where TModel : LabModel {
        public async Task Create (object? obj) {
            if (obj is not TDomain dM) return;
            await _repository.Create(dM.ToDbModel());
        }

        protected CreateDbModelCmd (IAdapter<Dispatcher> dA, IRepository<TModel> repository, Func<object?, bool>? canExecute = null)
            : base(dA, canExecute) {
            _repository = repository;
            Context = Create;
        }

        private readonly IRepository<TModel> _repository;
    }
}
