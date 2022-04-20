﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AplicacionCaja.integracion {
    using System.Data;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://integracion.somee.com/", ConfigurationName="integracion.IntegracionASMXSoap")]
    public interface IntegracionASMXSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://integracion.somee.com/Autenticacion", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet Autenticacion(string usuario, string contraseña, int pin, string clave);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://integracion.somee.com/Autenticacion", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> AutenticacionAsync(string usuario, string contraseña, int pin, string clave);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://integracion.somee.com/Transaccion", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet Transaccion(int ID_TipoTransaccion, int DbCr, string Comentario, int NoCuenta, decimal Monto, string clave);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://integracion.somee.com/Transaccion", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> TransaccionAsync(int ID_TipoTransaccion, int DbCr, string Comentario, int NoCuenta, decimal Monto, string clave);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://integracion.somee.com/ObtenerTodasCuentasDiferentes", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet ObtenerTodasCuentasDiferentes(int ID_Cliente, string clave);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://integracion.somee.com/ObtenerTodasCuentasDiferentes", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> ObtenerTodasCuentasDiferentesAsync(int ID_Cliente, string clave);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://integracion.somee.com/TransaccionATercero", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet TransaccionATercero(int NoCuenta, int Entidad, int ID_TipoEntidad, int ID_TipoTransaccion, int DbCr, string Comentario, decimal Monto, string clave);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://integracion.somee.com/TransaccionATercero", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> TransaccionATerceroAsync(int NoCuenta, int Entidad, int ID_TipoEntidad, int ID_TipoTransaccion, int DbCr, string Comentario, decimal Monto, string clave);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://integracion.somee.com/InsertarBeneficiario", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        bool InsertarBeneficiario(int ID_Beneficiario, int NoCuenta, int ID_TipoBeneficiario, string Nombre, int ID_Cliente, string clave);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://integracion.somee.com/InsertarBeneficiario", ReplyAction="*")]
        System.Threading.Tasks.Task<bool> InsertarBeneficiarioAsync(int ID_Beneficiario, int NoCuenta, int ID_TipoBeneficiario, string Nombre, int ID_Cliente, string clave);
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
        
        public System.Data.DataSet Autenticacion(string usuario, string contraseña, int pin, string clave) {
            return base.Channel.Autenticacion(usuario, contraseña, pin, clave);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> AutenticacionAsync(string usuario, string contraseña, int pin, string clave) {
            return base.Channel.AutenticacionAsync(usuario, contraseña, pin, clave);
        }
        
        public System.Data.DataSet Transaccion(int ID_TipoTransaccion, int DbCr, string Comentario, int NoCuenta, decimal Monto, string clave) {
            return base.Channel.Transaccion(ID_TipoTransaccion, DbCr, Comentario, NoCuenta, Monto, clave);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> TransaccionAsync(int ID_TipoTransaccion, int DbCr, string Comentario, int NoCuenta, decimal Monto, string clave) {
            return base.Channel.TransaccionAsync(ID_TipoTransaccion, DbCr, Comentario, NoCuenta, Monto, clave);
        }
        
        public System.Data.DataSet ObtenerTodasCuentasDiferentes(int ID_Cliente, string clave) {
            return base.Channel.ObtenerTodasCuentasDiferentes(ID_Cliente, clave);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> ObtenerTodasCuentasDiferentesAsync(int ID_Cliente, string clave) {
            return base.Channel.ObtenerTodasCuentasDiferentesAsync(ID_Cliente, clave);
        }
        
        public System.Data.DataSet TransaccionATercero(int NoCuenta, int Entidad, int ID_TipoEntidad, int ID_TipoTransaccion, int DbCr, string Comentario, decimal Monto, string clave) {
            return base.Channel.TransaccionATercero(NoCuenta, Entidad, ID_TipoEntidad, ID_TipoTransaccion, DbCr, Comentario, Monto, clave);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> TransaccionATerceroAsync(int NoCuenta, int Entidad, int ID_TipoEntidad, int ID_TipoTransaccion, int DbCr, string Comentario, decimal Monto, string clave) {
            return base.Channel.TransaccionATerceroAsync(NoCuenta, Entidad, ID_TipoEntidad, ID_TipoTransaccion, DbCr, Comentario, Monto, clave);
        }
        
        public bool InsertarBeneficiario(int ID_Beneficiario, int NoCuenta, int ID_TipoBeneficiario, string Nombre, int ID_Cliente, string clave) {
            return base.Channel.InsertarBeneficiario(ID_Beneficiario, NoCuenta, ID_TipoBeneficiario, Nombre, ID_Cliente, clave);
        }
        
        public System.Threading.Tasks.Task<bool> InsertarBeneficiarioAsync(int ID_Beneficiario, int NoCuenta, int ID_TipoBeneficiario, string Nombre, int ID_Cliente, string clave) {
            return base.Channel.InsertarBeneficiarioAsync(ID_Beneficiario, NoCuenta, ID_TipoBeneficiario, Nombre, ID_Cliente, clave);
        }
    }
}
