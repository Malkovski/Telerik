namespace TeleimotBg.Api.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using TeleimotBg.Api.Models.TemplateModels;
    using TeleimotBg.Services.Data.Contracts;
    using AutoMapper.QueryableExtensions;
    using TeleimotBg.GlobalConstants;

    public class RealEstatesController : ApiController
    {
        private readonly IRealEstateService estates;

        public RealEstatesController(IRealEstateService estateService)
        {
            this.estates = estateService;
        }

        //----------------GET----------------------

        public IHttpActionResult Get(int skip = UtilityConstants.DefaultSkipSize, int take = UtilityConstants.DefaultTakeSize)
        {
            var result = this.estates
            .All(skip, take)
            .ProjectTo<CommonRealEstateResponseModel>()
            .ToList();

            return this.Ok(result);
        }

        public IHttpActionResult Get(int id)
        {
            bool isAuthorized = this.User.Identity.IsAuthenticated;

            if (!isAuthorized)
            {
                var result = this.estates
                .GetEstateById(id)
                .ProjectTo<DetailedRealEstateResponseModel>()
                .ToList();

                return this.Ok(result);
            }
            else
            {
                var result = this.estates
                .GetEstateById(id)
                .ProjectTo<FullRealEstateResponseModel>()
                .FirstOrDefault();

                return this.Ok(result);
            }
        }

        //-----------POST-----------------------

        public IHttpActionResult Post(RealEstateSaveToDbRequestModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (model.SellingPrice == null && model.RentingPrice == null)
            {
                return this.BadRequest("Eighter seeling or renting prices must be set!");
            }

            var createdEstateId = this.estates.Add(model.Title, model.Description, model.Address, model.Contact,
                model.ConstructionYear,model.SellingPrice , model.RentingPrice, model.Type);

            var result = this.estates
                .GetEstateById(createdEstateId)
                .ProjectTo<CommonRealEstateResponseModel>()
                .FirstOrDefault();

            return this.Created("", result);
        }
    }
}
