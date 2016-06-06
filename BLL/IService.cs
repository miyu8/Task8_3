// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IService.cs" company="">
//   
// </copyright>
// <summary>
// Base interface for all services
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using LifeService;
using ServerImage;
using BLL;
namespace BLL
{
	using DAL;

    /// <summary>
    /// Base interface for all services
    /// </summary>
    /// 
    [ServiceContract]
    public interface IService
	{
        #region Public Properties

        /// <summary>
        /// UnitOfWork
        /// </summary>
        /// 
        [DataMember]
        IUnitOfWork unitOfWork { get; set; }

		#endregion
	}
}