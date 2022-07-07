using Smurfs.Business.Abstract;
using Smurfs.Core.Abstract;
using Smurfs.Entity.Concrete;
using Smurfs.Entity.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smurfs.Business.Concrete
{
    public class ProjectParametersManager : IProjectParametersService
    {
        private readonly IUnitOfWork _unitofwork;
        public ProjectParametersManager(IUnitOfWork unitofwork, IUserService userService)
        {
            _unitofwork = unitofwork;
            _userService = userService;
        }
        public async Task<List<ProjectParameters>> GetAllParameters()
        {
            return await _unitofwork.ProjectParameters.GetAll();

        }
        public async Task<ProjectParameters> GetByIdParameters(int id)
        {
            return await _unitofwork.ProjectParameters.GetById(id);
        }
        public void CreateParameters(ProjectParametersDto entity)
        {
            var ProjectParameters = _unitofwork.ProjectParameters.AddProjectParameters(entity);
            _unitofwork.ProjectParameters.Create(ProjectParameters);
            _unitofwork.Save();
        }
        public void UpdateParameters(ProjectParametersDto entity)
        {
            var ProjectParameters = _unitofwork.ProjectParameters.AddProjectParameters(entity);
            _unitofwork.ProjectParameters.Update(ProjectParameters);
            _unitofwork.Save();
        }
        public void DeleteParameters(ProjectParameters entity)
        {
            _unitofwork.ProjectParameters.Delete(entity);
            _unitofwork.Save();
        }
        private IUserService _userService;
        public void Calculate(int projecarpanı)
        {
            var users = _unitofwork.User.UserDetails();
            var project = _unitofwork.Project.GetProjectsDetails();
            var parametre = _unitofwork.ProjectParameters.ProjectParametersDetails();

            foreach (var user in users)
            {
                var gerceklesen = 0;
                var month = 0;
                var fark = 0;
                var kapasite = 0;
                var carpan = "";
                var verimyüzdesi = 0;
                var verimdeger = 0;
                var verimsonucu = 0;
                foreach (var proje in project)
                {
                    if (user.usergroup == "Developer" && proje.developer == user.Name + " " + user.Surname && proje.IsState == "0") //eğer bir olursa prim ödendi oluyor
                    {
                        if (proje.dZDStatus == "14 - Salesforce Fatura Talebi"
                            || proje.dZDStatus == "15 - Salesforce Fatura Onay"
                            || proje.dZDStatus == "16 - DZD e-Fatura"
                            || proje.dZDStatus == "17 - DZD Finans OK")
                        {
                            gerceklesen += int.Parse(proje.developerManDay);  // bir proje bir defa dahil edilme kontrolü  
                        }
                    }
                    if (user.usergroup == "Analyst" && proje.analyst == user.Name + " " + user.Surname && proje.IsState == "0")
                    {
                        if (proje.dZDStatus == "14 - Salesforce Fatura Talebi"
                            || proje.dZDStatus == "15 - Salesforce Fatura Onay"
                            || proje.dZDStatus == "16 - DZD e-Fatura"
                            || proje.dZDStatus == "17 - DZD Finans OK")
                        {
                            gerceklesen = int.Parse(proje.analystManDay);

                        }
                    }
                }
                month = Convert.ToDateTime(user.DateOfStart).Month;
                fark = DateTime.Now.Month - month;
                kapasite = fark * 20;
                carpan = parametre[0].ProjeCarpani;
                verimyüzdesi = (gerceklesen / kapasite) * 100;
                verimdeger = gerceklesen - kapasite;
                if (verimdeger < 0)
                {
                    verimdeger = 0;
                }
                verimsonucu = verimdeger * int.Parse(carpan);
                if (verimsonucu > 0)
                {
                    var result1 = _unitofwork.Premium.AddPremium(Id: 0, premiumDate: DateTime.Now, name: user.Name, surname: user.Surname, projectAmount: verimsonucu.ToString());
                    _unitofwork.Premium.Create(result1);
                    _unitofwork.Save();

                    var result2 = _unitofwork.GeneralPremium.AddGeneralPremium(Id: 0, premiumDate: DateTime.Now, name: user.Name, surname: user.Surname, projectAmount: verimsonucu.ToString());
                    _unitofwork.GeneralPremium.Create(result2);
                    _unitofwork.Save();
                }
            }
        }

        public List<ProjectParametersDto> ProjectParametersDetails()
        {
            var ProjectParameters = _unitofwork.ProjectParameters.ProjectParametersDetails();
            return ProjectParameters;
        }

        public Task<ProjectParameters> DeleteProjectParameters(int id)
        {
            return _unitofwork.ProjectParameters.DeleteProjectParameters(id);
        }
    }
}
