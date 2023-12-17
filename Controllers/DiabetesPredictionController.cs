using Microsoft.AspNetCore.Mvc;

namespace ML_WebApp.Controllers
{
    [ApiController]
    [Route("/")]
    public class DiabetesPredictionController : ControllerBase
    {

        public required DiabetesRiskModel.ModelInput sampleData;
        public required DiabetesRiskModel.ModelOutput prediction;

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(new
            {
                Message = "Hello, this is a Diabetes Prediction API!",
                Status = "Success"
            });
        }

        [HttpPost]
        public IActionResult Predict([FromBody] DiabetesRiskModel.ModelInput data)
        {
            //sampleData = new()
            //{
            //    Age = value.Age,
            //    Alopecia = value.Alopecia,
            //    Delayed_healing = value.Delayed_healing,
            //    Gender = value.Gender,
            //    Genital_thrush = value.Genital_thrush,
            //    Irritability = value.Irritability,
            //    Itching = value.Itching,
            //    Muscle_stiffness = value.Muscle_stiffness,
            //    Obesity = value.Obesity,
            //    Partial_paresis = value.Partial_paresis,
            //    Polydipsia = value.Polydipsia,
            //    Polyphagia = value.Polyphagia,
            //    Polyuria = value.Polyuria,
            //    Sudden_weight_loss = value.Sudden_weight_loss,
            //    Visual_blurring = value.Visual_blurring,
            //    Weakness = value.Weakness

            //};
            //sampleData = value;

            prediction = DiabetesRiskModel.Predict(data);

            return Ok(new
            {
                prediction.PredictedLabel,
                prediction.Score,
            });
        }
    }
}
