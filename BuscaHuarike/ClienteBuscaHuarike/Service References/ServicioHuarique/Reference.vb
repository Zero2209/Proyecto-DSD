﻿'------------------------------------------------------------------------------
' <auto-generated>
'     Este código fue generado por una herramienta.
'     Versión de runtime:4.0.30319.18444
'
'     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
'     se vuelve a generar el código.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System.Data

Namespace ServicioHuarique
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ServiceModel.ServiceContractAttribute(ConfigurationName:="ServicioHuarique.Service1Soap")>  _
    Public Interface Service1Soap
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/ObtenerDistritos", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function ObtenerDistritos() As System.Data.DataTable
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/ObtenerTiposComida", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function ObtenerTiposComida() As System.Data.DataTable
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/ObtenerHuarike", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function ObtenerHuarike() As System.Data.DataTable
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/ObtenerUsuario", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function ObtenerUsuario(ByVal PStrUsuario As String, ByVal PStrClave As String) As System.Data.DataTable
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/GrabarUsuario", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function GrabarUsuario(ByVal PStrUsuario As String, ByVal PStrClave As String, ByVal PStrNombre As String, ByVal PDteFechaRegistro As Date, ByVal PIntEstado As Integer) As System.Data.DataTable
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/ObtenerHuarikesPorDistrito", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function ObtenerHuarikesPorDistrito(ByVal PStrDistrito As String, ByVal PStrTipo As String) As System.Data.DataTable
    End Interface
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")>  _
    Public Interface Service1SoapChannel
        Inherits ServicioHuarique.Service1Soap, System.ServiceModel.IClientChannel
    End Interface
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")>  _
    Partial Public Class Service1SoapClient
        Inherits System.ServiceModel.ClientBase(Of ServicioHuarique.Service1Soap)
        Implements ServicioHuarique.Service1Soap
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String)
            MyBase.New(endpointConfigurationName)
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As String)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub
        
        Public Sub New(ByVal binding As System.ServiceModel.Channels.Binding, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
            MyBase.New(binding, remoteAddress)
        End Sub
        
        Public Function ObtenerDistritos() As System.Data.DataTable Implements ServicioHuarique.Service1Soap.ObtenerDistritos
            Return MyBase.Channel.ObtenerDistritos
        End Function
        
        Public Function ObtenerTiposComida() As System.Data.DataTable Implements ServicioHuarique.Service1Soap.ObtenerTiposComida
            Return MyBase.Channel.ObtenerTiposComida
        End Function
        
        Public Function ObtenerHuarike() As System.Data.DataTable Implements ServicioHuarique.Service1Soap.ObtenerHuarike
            Return MyBase.Channel.ObtenerHuarike
        End Function
        
        Public Function ObtenerUsuario(ByVal PStrUsuario As String, ByVal PStrClave As String) As System.Data.DataTable Implements ServicioHuarique.Service1Soap.ObtenerUsuario
            Return MyBase.Channel.ObtenerUsuario(PStrUsuario, PStrClave)
        End Function
        
        Public Function GrabarUsuario(ByVal PStrUsuario As String, ByVal PStrClave As String, ByVal PStrNombre As String, ByVal PDteFechaRegistro As Date, ByVal PIntEstado As Integer) As System.Data.DataTable Implements ServicioHuarique.Service1Soap.GrabarUsuario
            Return MyBase.Channel.GrabarUsuario(PStrUsuario, PStrClave, PStrNombre, PDteFechaRegistro, PIntEstado)
        End Function
        
        Public Function ObtenerHuarikesPorDistrito(ByVal PStrDistrito As String, ByVal PStrTipo As String) As System.Data.DataTable Implements ServicioHuarique.Service1Soap.ObtenerHuarikesPorDistrito
            Return MyBase.Channel.ObtenerHuarikesPorDistrito(PStrDistrito, PStrTipo)
        End Function
    End Class
End Namespace
