using AutoMapper;
using ProjectHandler.Models;
using ProjectHandler.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectHandler.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Mapping projet
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Projet , ProjetDTO>();
            });
            IMapper mapper = config.CreateMapper();
            var projet = new Projet ();
            var projetDto = mapper.Map<Projet, ProjetDTO >(projet);

            //Mapping Domaine
            var configDom = new MapperConfiguration(cfgDom =>
            {
                cfgDom.CreateMap<Domaine, DomaineDTO>();
            });
            IMapper mapperDom = configDom.CreateMapper();
            var domaine = new Domaine();
            var domaineDto = mapperDom.Map<Domaine, DomaineDTO>(domaine);

            //Mapping TypeForm
            var configTyp = new MapperConfiguration(cfgTyp =>
            {
                cfgTyp.CreateMap<TypeForm, TypeFormDTO>();
            });
            IMapper mapperTyp = configTyp.CreateMapper();
            var typeForm = new TypeForm();
            var typeFormDto = mapperTyp.Map<TypeForm, TypeFormDTO>(typeForm);

            //Mapping Formulaire
            var configForm = new MapperConfiguration(cfgForm =>
            {
                cfgForm.CreateMap<Formulaire, FormulaireDTO>();
            });
            IMapper mapperForm = configForm.CreateMapper();
            var fomulaire = new Formulaire();
            var formulaireDto = mapperForm.Map<Formulaire, FormulaireDTO>(fomulaire);

            //Mapping Component
            var configCom = new MapperConfiguration(cfgCom =>
            {
                cfgCom.CreateMap<Component, ComponentDTO>();
            });
            IMapper mapperCom = configCom.CreateMapper();
            var component = new Component();
            var componentDto = mapperCom.Map<Component, ComponentDTO>(component);

            //Mapping TypeDonnee
            var configDon = new MapperConfiguration(cfgDon =>
            {
                cfgDon.CreateMap<TypeDonnee, TypeDonneeDTO>();
            });
            IMapper mapperDon = configDon.CreateMapper();
            var typeDonnee = new TypeDonnee();
            var typeDonneeDto = mapperDon.Map<TypeDonnee, TypeDonneeDTO>(typeDonnee);

            //Mapping Question
            var configQuest = new MapperConfiguration(cfgQuest =>
            {
                cfgQuest.CreateMap<Question, QuestionDTO>();
            });
            IMapper mapperQuest = configQuest.CreateMapper();
            var question = new Question();
            var questionDto = mapperQuest.Map<Question, QuestionDTO>(question);

            //Mapping QuestionsByFormulaire
            var confQuestForm = new MapperConfiguration(cfgQuesForm =>
            {
                cfgQuesForm.CreateMap<Question, QuestionDTO>();
            });
            IMapper mapperQuestForm = confQuestForm.CreateMapper();
            var questionForm = new Question();
            var questionFormDto = mapperQuestForm.Map<Question, QuestionDTO>(question);

            //Mapping Dynamic Reference
            var configDyn = new MapperConfiguration(cfgDyn =>
            {
                cfgDyn.CreateMap<Question, QuestionDTO>();
            });
            IMapper mapperDyn = configDyn.CreateMapper();
            var dynamicReference = new DynamicReference();
            var dynamicReferenceDto = mapperDyn.Map<DynamicReference, DynamicReferenceDTO>(dynamicReference);

            //Reponse
            var configRep = new MapperConfiguration(cfgRep =>
            {
                cfgRep.CreateMap<Reponse, ReponseDTO>();
            });
            IMapper mapperRep = configRep.CreateMapper();
            var reponse = new Reponse();
            var reponseDto = mapperRep.Map<Reponse, ReponseDTO>(reponse);
        }
    }
}