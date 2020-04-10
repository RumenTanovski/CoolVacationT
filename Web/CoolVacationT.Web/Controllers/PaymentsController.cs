namespace CoolVacationT.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using CoolVacationT.Services.Data;
    using CoolVacationT.Web.CloudinaryHelper;
    using CoolVacationT.Web.ViewModels.Payments.InputModel;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    public class PaymentsController : Controller
    {
        private readonly IPaymentService paymentService;
        private readonly Cloudinary cloudinary;

        public PaymentsController(
            IPaymentService paymentService,
            Cloudinary cloudinary)
        {
            this.paymentService = paymentService;
            this.cloudinary = cloudinary;
        }

        [Authorize]
        public IActionResult Add()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add(CreatePaymentInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            if (inputModel.PaymentDocument != null)
            {
                var stringFileNameCloud = await CloudinaryExtencions.UploadAsync(this.cloudinary, inputModel.PaymentDocument);
                await this.paymentService.AddAsync(inputModel.AmountPaid, inputModel.DocumentNumber, stringFileNameCloud);
            }
            else
            {
                await this.paymentService.AddAsync(inputModel.AmountPaid, inputModel.DocumentNumber);
            }

            return this.Redirect("/RelaxPrograms/Add");
        }

       // public async Task<IActionResult> Upload(IFormFile file)
       // {
       //    await CloudinaryExtencions.UploadAsync(this.cloudinary, file);
       //
       //   // var uploadParams = new ImageUploadParams()
       //   // {
       //   //     File = new FileDescription(@"C:\vre\userDocument.jpg")
       //   // };
       //   // var uploadResult = await cloudinary.UploadAsync(uploadParams);
       //    return this.Redirect("/");
       // }
    }
}
