using Microsoft.AspNetCore.Mvc;

namespace ML_WebApp.Controllers
{
    [ApiController]
    [Route("/")]
    public class DiabetesPredictionController : ControllerBase
    {
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
            prediction = DiabetesRiskModel.Predict(data);

            return Ok(new
            {
                prediction.PredictedLabel,
                prediction.Score,
            });
        }
    }
}
