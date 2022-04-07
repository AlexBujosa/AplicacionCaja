﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AplicacionCaja.integracion {
    using System.Data;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://integracion.somee.com/", ConfigurationName="integracion.IntegracionASMXSoap")]
    public interface IntegracionASMXSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://integracion.somee.com/HelloWorld", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string HelloWorld(string usuario, string contraseña, int pin);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://integracion.somee.com/HelloWorld", ReplyAction="*")]
        System.Threading.Tasks.Task<string> HelloWorldAsync(string usuario, string contraseña, int pin);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://integracion.somee.com/Autenticacion", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet Autenticacion(string usuario, string contraseña, int pin);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://integracion.somee.com/Autenticacion", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> AutenticacionAsync(string usuario, string contraseña, int pin);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://integracion.somee.com/Transaccion", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet Transaccion(int ID_TipoTransaccion, int DbCr, string Comentario, int NoCuenta, decimal Monto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://integracion.somee.com/Transaccion", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> TransaccionAsync(int ID_TipoTransaccion, int DbCr, string Comentario, int NoCuenta, decimal Monto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://integracion.somee.com/ObtenerTodasCuentasDiferentes", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet ObtenerTodasCuentasDiferentes(int ID_Cliente);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://integracion.somee.com/ObtenerTodasCuentasDiferentes", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> ObtenerTodasCuentasDiferentesAsync(int ID_Cliente);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://integracion.somee.com/TransaccionATercero", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet TransaccionATercero(int NoCuenta, int Entidad, int ID_TipoEntidad, int ID_TipoTransaccion, int DbCr, string Comentario, decimal Monto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://integracion.somee.com/TransaccionATercero", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> TransaccionATerceroAsync(int NoCuenta, int Entidad, int ID_TipoEntidad, int ID_TipoTransaccion, int DbCr, string Comentario, decimal Monto);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IntegracionASMXSoapChannel : AplicacionCaja.integracion.IntegracionASMXSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class IntegracionASMXSoapClient : System.ServiceModel.ClientBase<AplicacionCaja.integracion.IntegracionASMXSoap>, AplicacionCaja.integracion.IntegracionASMXSoap {
        
        public IntegracionASMXSoapClient() {
        }
        
        public IntegracionASMXSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public IntegracionASMXSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public IntegracionASMXSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public IntegracionASMXSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string HelloWorld(string usuario, string contraseña, int pin) {
            return base.Channel.HelloWorld(usuario, contraseña, pin);
        }
        
        public System.Threading.Tasks.Task<string> HelloWorldAsync(string usuario, string contraseña, int pin) {
            return base.Channel.HelloWorldAsync(usuario, contraseña, pin);
        }
        
        public System.Data.DataSet Autenticacion(string usuario, string contraseña, int pin) {
            return base.Channel.Autenticacion(usuario, contraseña, pin);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> AutenticacionAsync(string usuario, string contraseña, int pin) {
            return base.Channel.AutenticacionAsync(usuario, contraseña, pin);
        }
        
        public System.Data.DataSet Transaccion(int ID_TipoTransaccion, int DbCr, string Comentario, int NoCuenta, decimal Monto) {
            return base.Channel.Transaccion(ID_TipoTransaccion, DbCr, Comentario, NoCuenta, Monto);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> TransaccionAsync(int ID_TipoTransaccion, int DbCr, string Comentario, int NoCuenta, decimal Monto) {
            return base.Channel.TransaccionAsync(ID_TipoTransaccion, DbCr, Comentario, NoCuenta, Monto);
        }
        
        public System.Data.DataSet ObtenerTodasCuentasDiferentes(int ID_Cliente) {
            return base.Channel.ObtenerTodasCuentasDiferentes(ID_Cliente);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> ObtenerTodasCuentasDiferentesAsync(int ID_Cliente) {
            return base.Channel.ObtenerTodasCuentasDiferentesAsync(ID_Cliente);
        }
        
        public System.Data.DataSet TransaccionATercero(int NoCuenta, int Entidad, int ID_TipoEntidad, int ID_TipoTransaccion, int DbCr, string Comentario, decimal Monto) {
            return base.Channel.TransaccionATercero(NoCuenta, Entidad, ID_TipoEntidad, ID_TipoTransaccion, DbCr, Comentario, Monto);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> TransaccionATerceroAsync(int NoCuenta, int Entidad, int ID_TipoEntidad, int ID_TipoTransaccion, int DbCr, string Comentario, decimal Monto) {
            return base.Channel.TransaccionATerceroAsync(NoCuenta, Entidad, ID_TipoEntidad, ID_TipoTransaccion, DbCr, Comentario, Monto);
        }
    }
}
