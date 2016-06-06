﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LifeService
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="GameImage", Namespace="http://schemas.datacontract.org/2004/07/LifeService")]
    public partial class GameImage : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private bool IsEndedField;
        
        private bool IsInterruptedField;
        
        private int IterationField;
        
        private int RunIDField;
        
        private int SaveIdField;
        
        private int SizeXField;
        
        private int SizeYField;
        
        private int TypeField;
        
        private int WatchersField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsEnded
        {
            get
            {
                return this.IsEndedField;
            }
            set
            {
                this.IsEndedField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsInterrupted
        {
            get
            {
                return this.IsInterruptedField;
            }
            set
            {
                this.IsInterruptedField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Iteration
        {
            get
            {
                return this.IterationField;
            }
            set
            {
                this.IterationField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int RunID
        {
            get
            {
                return this.RunIDField;
            }
            set
            {
                this.RunIDField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int SaveId
        {
            get
            {
                return this.SaveIdField;
            }
            set
            {
                this.SaveIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int SizeX
        {
            get
            {
                return this.SizeXField;
            }
            set
            {
                this.SizeXField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int SizeY
        {
            get
            {
                return this.SizeYField;
            }
            set
            {
                this.SizeYField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Type
        {
            get
            {
                return this.TypeField;
            }
            set
            {
                this.TypeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Watchers
        {
            get
            {
                return this.WatchersField;
            }
            set
            {
                this.WatchersField = value;
            }
        }
    }
}
namespace BLL
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="SaveService", Namespace="http://schemas.datacontract.org/2004/07/BLL")]
    public partial class SaveService : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
    }
}
namespace Life.Initialization
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Options", Namespace="http://schemas.datacontract.org/2004/07/Life.Initialization")]
    public partial class Options : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private Life.LivingProperty.GameProperty gamePropertyField;
        
        private Life.LivingProperty.Grass1Property grass1PropertyField;
        
        private Life.LivingProperty.Grass2Property grass2PropertyField;
        
        private Life.LivingProperty.Herbivorous1Property herbivorous1PropertyField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Life.LivingProperty.GameProperty gameProperty
        {
            get
            {
                return this.gamePropertyField;
            }
            set
            {
                this.gamePropertyField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Life.LivingProperty.Grass1Property grass1Property
        {
            get
            {
                return this.grass1PropertyField;
            }
            set
            {
                this.grass1PropertyField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Life.LivingProperty.Grass2Property grass2Property
        {
            get
            {
                return this.grass2PropertyField;
            }
            set
            {
                this.grass2PropertyField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Life.LivingProperty.Herbivorous1Property herbivorous1Property
        {
            get
            {
                return this.herbivorous1PropertyField;
            }
            set
            {
                this.herbivorous1PropertyField = value;
            }
        }
    }
}
namespace Life.LivingProperty
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="GameProperty", Namespace="http://schemas.datacontract.org/2004/07/Life.LivingProperty")]
    public partial class GameProperty : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private string NamePlayField;
        
        private string NamePlayerField;
        
        private int SizeXField;
        
        private int SizeYField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string NamePlay
        {
            get
            {
                return this.NamePlayField;
            }
            set
            {
                this.NamePlayField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string NamePlayer
        {
            get
            {
                return this.NamePlayerField;
            }
            set
            {
                this.NamePlayerField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int SizeX
        {
            get
            {
                return this.SizeXField;
            }
            set
            {
                this.SizeXField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int SizeY
        {
            get
            {
                return this.SizeYField;
            }
            set
            {
                this.SizeYField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Grass1Property", Namespace="http://schemas.datacontract.org/2004/07/Life.LivingProperty")]
    public partial class Grass1Property : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private int DeathField;
        
        private int ReproductionField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Death
        {
            get
            {
                return this.DeathField;
            }
            set
            {
                this.DeathField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Reproduction
        {
            get
            {
                return this.ReproductionField;
            }
            set
            {
                this.ReproductionField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Grass2Property", Namespace="http://schemas.datacontract.org/2004/07/Life.LivingProperty")]
    public partial class Grass2Property : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private int CourseField;
        
        private int FrequencyField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Course
        {
            get
            {
                return this.CourseField;
            }
            set
            {
                this.CourseField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Frequency
        {
            get
            {
                return this.FrequencyField;
            }
            set
            {
                this.FrequencyField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Herbivorous1Property", Namespace="http://schemas.datacontract.org/2004/07/Life.LivingProperty")]
    public partial class Herbivorous1Property : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private int EnergyBaseField;
        
        private int EnergyBaseBeginField;
        
        private int EnergyConsumptionField;
        
        private int EnergyGrassField;
        
        private int Grass2RadiusField;
        
        private int SpeedField;
        
        private int StartRotField;
        
        private int TimeRotField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int EnergyBase
        {
            get
            {
                return this.EnergyBaseField;
            }
            set
            {
                this.EnergyBaseField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int EnergyBaseBegin
        {
            get
            {
                return this.EnergyBaseBeginField;
            }
            set
            {
                this.EnergyBaseBeginField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int EnergyConsumption
        {
            get
            {
                return this.EnergyConsumptionField;
            }
            set
            {
                this.EnergyConsumptionField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int EnergyGrass
        {
            get
            {
                return this.EnergyGrassField;
            }
            set
            {
                this.EnergyGrassField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Grass2Radius
        {
            get
            {
                return this.Grass2RadiusField;
            }
            set
            {
                this.Grass2RadiusField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Speed
        {
            get
            {
                return this.SpeedField;
            }
            set
            {
                this.SpeedField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int StartRot
        {
            get
            {
                return this.StartRotField;
            }
            set
            {
                this.StartRotField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int TimeRot
        {
            get
            {
                return this.TimeRotField;
            }
            set
            {
                this.TimeRotField = value;
            }
        }
    }
}


[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(ConfigurationName="ILifeService")]
public interface ILifeService
{
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILifeService/Save", ReplyAction="http://tempuri.org/ILifeService/SaveResponse")]
    bool Save(LifeService.GameImage gameImage);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILifeService/Save", ReplyAction="http://tempuri.org/ILifeService/SaveResponse")]
    System.Threading.Tasks.Task<bool> SaveAsync(LifeService.GameImage gameImage);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILifeService/GetStudentById", ReplyAction="http://tempuri.org/ILifeService/GetStudentByIdResponse")]
    BLL.SaveService GetStudentById(int id);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILifeService/GetStudentById", ReplyAction="http://tempuri.org/ILifeService/GetStudentByIdResponse")]
    System.Threading.Tasks.Task<BLL.SaveService> GetStudentByIdAsync(int id);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILifeService/GetAllSave", ReplyAction="http://tempuri.org/ILifeService/GetAllSaveResponse")]
    BLL.SaveService[] GetAllSave();
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILifeService/GetAllSave", ReplyAction="http://tempuri.org/ILifeService/GetAllSaveResponse")]
    System.Threading.Tasks.Task<BLL.SaveService[]> GetAllSaveAsync();
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILifeService/StartNewGame", ReplyAction="http://tempuri.org/ILifeService/StartNewGameResponse")]
    void StartNewGame(int type, Life.Initialization.Options newOptions);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILifeService/StartNewGame", ReplyAction="http://tempuri.org/ILifeService/StartNewGameResponse")]
    System.Threading.Tasks.Task StartNewGameAsync(int type, Life.Initialization.Options newOptions);
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public interface ILifeServiceChannel : ILifeService, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public partial class LifeServiceClient : System.ServiceModel.ClientBase<ILifeService>, ILifeService
{
    
    public LifeServiceClient()
    {
    }
    
    public LifeServiceClient(string endpointConfigurationName) : 
            base(endpointConfigurationName)
    {
    }
    
    public LifeServiceClient(string endpointConfigurationName, string remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public LifeServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public LifeServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
    }
    
    public bool Save(LifeService.GameImage gameImage)
    {
        return base.Channel.Save(gameImage);
    }
    
    public System.Threading.Tasks.Task<bool> SaveAsync(LifeService.GameImage gameImage)
    {
        return base.Channel.SaveAsync(gameImage);
    }
    
    public BLL.SaveService GetStudentById(int id)
    {
        return base.Channel.GetStudentById(id);
    }
    
    public System.Threading.Tasks.Task<BLL.SaveService> GetStudentByIdAsync(int id)
    {
        return base.Channel.GetStudentByIdAsync(id);
    }
    
    public BLL.SaveService[] GetAllSave()
    {
        return base.Channel.GetAllSave();
    }
    
    public System.Threading.Tasks.Task<BLL.SaveService[]> GetAllSaveAsync()
    {
        return base.Channel.GetAllSaveAsync();
    }
    
    public void StartNewGame(int type, Life.Initialization.Options newOptions)
    {
        base.Channel.StartNewGame(type, newOptions);
    }
    
    public System.Threading.Tasks.Task StartNewGameAsync(int type, Life.Initialization.Options newOptions)
    {
        return base.Channel.StartNewGameAsync(type, newOptions);
    }
}
