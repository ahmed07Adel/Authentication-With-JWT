using APIJWT.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIJWT.Controllers
{
    [Authorize(Roles = RolesModel.admin)]
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {

    }
}
