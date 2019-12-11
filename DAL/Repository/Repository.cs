using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class Repository
    {
        private BankEntities db;
        private ClientRepository clientRepository;
        private ProgramRepository programRepository;
        private KreditRepository kreditRepository;
        private OperaciiRepository operaciiRepository;
        private SchetRepository schetRepository;
        private SotrudnicRepository sotrudnicRepository;
        private StatusRepository statusRepository;
        private Tip_operRepository tip_OperRepository;
        private Tip_progRepository tip_ProgRepository;
        private ValuteRepository valuteRepository;
        private VkladRepository vkladRepository;

        public Repository()
        {
            db = new BankEntities();
        }

        public ClientRepository Client
        {
            get
            {
                if (clientRepository == null)
                    clientRepository = new ClientRepository(db);
                return clientRepository;
            }
        }

        public ProgramRepository Program
        {
            get
            {
                if (programRepository == null)
                    programRepository = new ProgramRepository(db);
                return programRepository;
            }
        }

        public OperaciiRepository Operacii
        {
            get
            {
                if (operaciiRepository == null)
                    operaciiRepository = new OperaciiRepository(db);
                return operaciiRepository;
            }
        }

        public KreditRepository Kredit
        {
            get
            {
                if (kreditRepository == null)
                    kreditRepository = new KreditRepository(db);
                return kreditRepository;
            }
        }

        public SchetRepository Schet
        {
            get
            {
                if (schetRepository == null)
                    schetRepository = new SchetRepository(db);
                return schetRepository;
            }
        }

        public SotrudnicRepository Sotrudnic
        {
            get
            {
                if (sotrudnicRepository == null)
                    sotrudnicRepository = new SotrudnicRepository(db);
                return sotrudnicRepository;
            }
        }

        public StatusRepository Status
        {
            get
            {
                if (statusRepository == null)
                    statusRepository = new StatusRepository(db);
                return statusRepository;
            }
        }

        public Tip_operRepository Tip_Oper
        {
            get
            {
                if (tip_OperRepository == null)
                    tip_OperRepository = new Tip_operRepository(db);
                return tip_OperRepository;
            }
        }

        public Tip_progRepository Tip_Prog
        {
            get
            {
                if (tip_ProgRepository == null)
                    tip_ProgRepository = new Tip_progRepository(db);
                return tip_ProgRepository;
            }
        }

        public ValuteRepository Valute
        {
            get
            {
                if (valuteRepository == null)
                    valuteRepository = new ValuteRepository(db);
                return valuteRepository;
            }
        }
        
        public VkladRepository Vklad
        {
            get
            {
                if (vkladRepository == null)
                    vkladRepository = new VkladRepository(db);
                return vkladRepository;
            }
        }
        public int Save()
        {
            return db.SaveChanges();
        }
    }
}
