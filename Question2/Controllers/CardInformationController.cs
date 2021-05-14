using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Play_Web.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Question2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CardInformationController : ControllerBase
    {

        //Dummy card data to help with my response data structure and testing
        List<CardData> CardDatas = new List<CardData>()
        {
            new CardData
            {
                Id = 1,
                Bank = "Wema",
                Scheme = "MasterCard",
                CardNumber = "2234",
                Type = "Credit"
            },

            new CardData
            {
                Id = 2,
                Bank = "UBA",
                Scheme = "VISA",
                CardNumber = "5564",
                Type = "Debit"
            }
        };

        //Dummy card data to help with my response data structure and testing
        List<Statistics> StatsData = new List<Statistics>()
        {
            new Statistics
            {
                CardNumber = "5564",
                NumberOfHits = 15,
            },

            new Statistics
            {
                CardNumber = "3365",
                NumberOfHits = 10
            },

            new Statistics
            {
                CardNumber = "2234",
                NumberOfHits = 8
            },

            new Statistics
            {
                CardNumber = "1198",
                NumberOfHits = 7
            },

            new Statistics
            {
                CardNumber = "8870",
                NumberOfHits = 8
            },

            new Statistics
            {
                CardNumber = "2090",
                NumberOfHits = 24
            },
        };

        Auth myClass = new Auth();


        [Route("card-scheme/verify/{cardNumber}")]
        [HttpGet]
        public async Task<IActionResult> VerifyCard([FromHeader] AuthenticationData authData, string cardNumber)
        {
            try
            {

                var authResult = myClass.AuthenticateHeader(authData);

                if (!authResult.Item1) return Unauthorized(new { authResult.Item1, authResult.Item2 });


                if (cardNumber == null)
                {
                    return BadRequest(new { Error = "Please input card number" });
                }

                var cardData = CardDatas.Where(c => c.CardNumber == cardNumber).FirstOrDefault();

                if(cardData == null)
                {
                    return NotFound(new { Error = "Card with card number " + cardNumber + " not found" });
                }

                return Ok(new { success = "True", payload = new { scheme = cardData.Scheme, type = cardData.Type, bank = cardData.Bank} });
            }
            catch(Exception ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }
        }



        [Route("card-scheme/stats")]
        [HttpGet]
        public async Task<IActionResult> HitCounts([FromHeader] AuthenticationData authData, int start, int limit)
        {
            try
            {

                var authResult = myClass.AuthenticateHeader(authData);

                if (!authResult.Item1) return Unauthorized(new { authResult.Item1, authResult.Item2 });

                if (limit == 0) limit = StatsData.Count;

                if (limit >= StatsData.Count) limit = StatsData.Count;

                var statisticData = StatsData.GetRange(start, limit).OrderByDescending(c => c.NumberOfHits).ToList();

                Dictionary<string, int> payload = new Dictionary<string, int>();

                foreach(var item in statisticData)
                {
                    payload.Add(item.CardNumber, item.NumberOfHits);
                }

                payload.OrderByDescending(c => c.Value);

                return Ok(new { success = "true", start = start, limit = limit, size = StatsData.Count, payload });
            }
            catch(Exception ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }
        }



    }



    public class CardData
    {
        public int Id { get; set; }
        public string CardNumber { get; set; }
        public string Scheme { get; set; }
        public string Type { get; set; }
        public string Bank { get; set; }

    }


    public class Statistics
    {
        public string CardNumber { get; set; }
        public int NumberOfHits { get; set; }

    }

    public class AuthenticationData
    {
        [Required]
        public string Authorization = "3line 4n+F7tDHDaFCoPkDDCtHMX6fvNIolyzMLFONT5c4XSYBg7VYFg1uMDYW7b3wDOs+rKL4QjaY2A100Jufsg1XFA==";

        [Required]
        public string TimeStamp = "1617953042";

        [Required]
        public string AppKey = "test_20191123132233";

    }
}
