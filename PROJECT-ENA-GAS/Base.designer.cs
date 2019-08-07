﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PROJECT_ENA_GAS
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="ENAGAS")]
	public partial class BaseDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Definiciones de métodos de extensibilidad
    partial void OnCreated();
    partial void InsertClientes(Clientes instance);
    partial void UpdateClientes(Clientes instance);
    partial void DeleteClientes(Clientes instance);
    partial void InsertUsuario(Usuario instance);
    partial void UpdateUsuario(Usuario instance);
    partial void DeleteUsuario(Usuario instance);
    partial void InsertChimbo(Chimbo instance);
    partial void UpdateChimbo(Chimbo instance);
    partial void DeleteChimbo(Chimbo instance);
    partial void InsertInventario(Inventario instance);
    partial void UpdateInventario(Inventario instance);
    partial void DeleteInventario(Inventario instance);
    partial void InsertCargo(Cargo instance);
    partial void UpdateCargo(Cargo instance);
    partial void DeleteCargo(Cargo instance);
    #endregion
		
		public BaseDataContext() : 
				base(global::PROJECT_ENA_GAS.Properties.Settings.Default.ENAGASConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public BaseDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public BaseDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public BaseDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public BaseDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Clientes> Clientes
		{
			get
			{
				return this.GetTable<Clientes>();
			}
		}
		
		public System.Data.Linq.Table<Usuario> Usuario
		{
			get
			{
				return this.GetTable<Usuario>();
			}
		}
		
		public System.Data.Linq.Table<Chimbo> Chimbo
		{
			get
			{
				return this.GetTable<Chimbo>();
			}
		}
		
		public System.Data.Linq.Table<Inventario> Inventario
		{
			get
			{
				return this.GetTable<Inventario>();
			}
		}
		
		public System.Data.Linq.Table<Cargo> Cargo
		{
			get
			{
				return this.GetTable<Cargo>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="EnaGas.Clientes")]
	public partial class Clientes : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _idCliente;
		
		private string _identidad;
		
		private string _nombre;
		
		private string _apellido;
		
		private string _direccion;
		
		private string _telefono;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidClienteChanging(int value);
    partial void OnidClienteChanged();
    partial void OnidentidadChanging(string value);
    partial void OnidentidadChanged();
    partial void OnnombreChanging(string value);
    partial void OnnombreChanged();
    partial void OnapellidoChanging(string value);
    partial void OnapellidoChanged();
    partial void OndireccionChanging(string value);
    partial void OndireccionChanged();
    partial void OntelefonoChanging(string value);
    partial void OntelefonoChanged();
    #endregion
		
		public Clientes()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_idCliente", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int idCliente
		{
			get
			{
				return this._idCliente;
			}
			set
			{
				if ((this._idCliente != value))
				{
					this.OnidClienteChanging(value);
					this.SendPropertyChanging();
					this._idCliente = value;
					this.SendPropertyChanged("idCliente");
					this.OnidClienteChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_identidad", DbType="VarChar(13) NOT NULL", CanBeNull=false)]
		public string identidad
		{
			get
			{
				return this._identidad;
			}
			set
			{
				if ((this._identidad != value))
				{
					this.OnidentidadChanging(value);
					this.SendPropertyChanging();
					this._identidad = value;
					this.SendPropertyChanged("identidad");
					this.OnidentidadChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_nombre", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string nombre
		{
			get
			{
				return this._nombre;
			}
			set
			{
				if ((this._nombre != value))
				{
					this.OnnombreChanging(value);
					this.SendPropertyChanging();
					this._nombre = value;
					this.SendPropertyChanged("nombre");
					this.OnnombreChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_apellido", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string apellido
		{
			get
			{
				return this._apellido;
			}
			set
			{
				if ((this._apellido != value))
				{
					this.OnapellidoChanging(value);
					this.SendPropertyChanging();
					this._apellido = value;
					this.SendPropertyChanged("apellido");
					this.OnapellidoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_direccion", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
		public string direccion
		{
			get
			{
				return this._direccion;
			}
			set
			{
				if ((this._direccion != value))
				{
					this.OndireccionChanging(value);
					this.SendPropertyChanging();
					this._direccion = value;
					this.SendPropertyChanged("direccion");
					this.OndireccionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_telefono", DbType="VarChar(20)")]
		public string telefono
		{
			get
			{
				return this._telefono;
			}
			set
			{
				if ((this._telefono != value))
				{
					this.OntelefonoChanging(value);
					this.SendPropertyChanging();
					this._telefono = value;
					this.SendPropertyChanged("telefono");
					this.OntelefonoChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="EnaGas.Usuario")]
	public partial class Usuario : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _idUsuario;
		
		private string _nombreUsuario;
		
		private string _contraseña;
		
		private string _cargo;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidUsuarioChanging(int value);
    partial void OnidUsuarioChanged();
    partial void OnnombreUsuarioChanging(string value);
    partial void OnnombreUsuarioChanged();
    partial void OncontraseñaChanging(string value);
    partial void OncontraseñaChanged();
    partial void OncargoChanging(string value);
    partial void OncargoChanged();
    #endregion
		
		public Usuario()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_idUsuario", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int idUsuario
		{
			get
			{
				return this._idUsuario;
			}
			set
			{
				if ((this._idUsuario != value))
				{
					this.OnidUsuarioChanging(value);
					this.SendPropertyChanging();
					this._idUsuario = value;
					this.SendPropertyChanged("idUsuario");
					this.OnidUsuarioChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_nombreUsuario", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
		public string nombreUsuario
		{
			get
			{
				return this._nombreUsuario;
			}
			set
			{
				if ((this._nombreUsuario != value))
				{
					this.OnnombreUsuarioChanging(value);
					this.SendPropertyChanging();
					this._nombreUsuario = value;
					this.SendPropertyChanged("nombreUsuario");
					this.OnnombreUsuarioChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_contraseña", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
		public string contraseña
		{
			get
			{
				return this._contraseña;
			}
			set
			{
				if ((this._contraseña != value))
				{
					this.OncontraseñaChanging(value);
					this.SendPropertyChanging();
					this._contraseña = value;
					this.SendPropertyChanged("contraseña");
					this.OncontraseñaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cargo", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string cargo
		{
			get
			{
				return this._cargo;
			}
			set
			{
				if ((this._cargo != value))
				{
					this.OncargoChanging(value);
					this.SendPropertyChanging();
					this._cargo = value;
					this.SendPropertyChanged("cargo");
					this.OncargoChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="EnaGas.Chimbo")]
	public partial class Chimbo : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _idChimbo;
		
		private System.Nullable<int> _idCantidad;
		
		private string _peso;
		
		private decimal _precio;
		
		private EntityRef<Inventario> _Inventario;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChimboChanging(int value);
    partial void OnidChimboChanged();
    partial void OnidCantidadChanging(System.Nullable<int> value);
    partial void OnidCantidadChanged();
    partial void OnpesoChanging(string value);
    partial void OnpesoChanged();
    partial void OnprecioChanging(decimal value);
    partial void OnprecioChanged();
    #endregion
		
		public Chimbo()
		{
			this._Inventario = default(EntityRef<Inventario>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_idChimbo", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int idChimbo
		{
			get
			{
				return this._idChimbo;
			}
			set
			{
				if ((this._idChimbo != value))
				{
					this.OnidChimboChanging(value);
					this.SendPropertyChanging();
					this._idChimbo = value;
					this.SendPropertyChanged("idChimbo");
					this.OnidChimboChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_idCantidad", DbType="Int")]
		public System.Nullable<int> idCantidad
		{
			get
			{
				return this._idCantidad;
			}
			set
			{
				if ((this._idCantidad != value))
				{
					if (this._Inventario.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnidCantidadChanging(value);
					this.SendPropertyChanging();
					this._idCantidad = value;
					this.SendPropertyChanged("idCantidad");
					this.OnidCantidadChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_peso", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
		public string peso
		{
			get
			{
				return this._peso;
			}
			set
			{
				if ((this._peso != value))
				{
					this.OnpesoChanging(value);
					this.SendPropertyChanging();
					this._peso = value;
					this.SendPropertyChanged("peso");
					this.OnpesoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_precio", DbType="Money NOT NULL")]
		public decimal precio
		{
			get
			{
				return this._precio;
			}
			set
			{
				if ((this._precio != value))
				{
					this.OnprecioChanging(value);
					this.SendPropertyChanging();
					this._precio = value;
					this.SendPropertyChanged("precio");
					this.OnprecioChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Inventario_Chimbo", Storage="_Inventario", ThisKey="idCantidad", OtherKey="idCantidad", IsForeignKey=true, DeleteRule="CASCADE")]
		public Inventario Inventario
		{
			get
			{
				return this._Inventario.Entity;
			}
			set
			{
				Inventario previousValue = this._Inventario.Entity;
				if (((previousValue != value) 
							|| (this._Inventario.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Inventario.Entity = null;
						previousValue.Chimbo.Remove(this);
					}
					this._Inventario.Entity = value;
					if ((value != null))
					{
						value.Chimbo.Add(this);
						this._idCantidad = value.idCantidad;
					}
					else
					{
						this._idCantidad = default(Nullable<int>);
					}
					this.SendPropertyChanged("Inventario");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="EnaGas.Inventario")]
	public partial class Inventario : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _idCantidad;
		
		private System.Nullable<int> _cantidad;
		
		private EntitySet<Chimbo> _Chimbo;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidCantidadChanging(int value);
    partial void OnidCantidadChanged();
    partial void OncantidadChanging(System.Nullable<int> value);
    partial void OncantidadChanged();
    #endregion
		
		public Inventario()
		{
			this._Chimbo = new EntitySet<Chimbo>(new Action<Chimbo>(this.attach_Chimbo), new Action<Chimbo>(this.detach_Chimbo));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_idCantidad", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int idCantidad
		{
			get
			{
				return this._idCantidad;
			}
			set
			{
				if ((this._idCantidad != value))
				{
					this.OnidCantidadChanging(value);
					this.SendPropertyChanging();
					this._idCantidad = value;
					this.SendPropertyChanged("idCantidad");
					this.OnidCantidadChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cantidad", DbType="Int")]
		public System.Nullable<int> cantidad
		{
			get
			{
				return this._cantidad;
			}
			set
			{
				if ((this._cantidad != value))
				{
					this.OncantidadChanging(value);
					this.SendPropertyChanging();
					this._cantidad = value;
					this.SendPropertyChanged("cantidad");
					this.OncantidadChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Inventario_Chimbo", Storage="_Chimbo", ThisKey="idCantidad", OtherKey="idCantidad")]
		public EntitySet<Chimbo> Chimbo
		{
			get
			{
				return this._Chimbo;
			}
			set
			{
				this._Chimbo.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Chimbo(Chimbo entity)
		{
			this.SendPropertyChanging();
			entity.Inventario = this;
		}
		
		private void detach_Chimbo(Chimbo entity)
		{
			this.SendPropertyChanging();
			entity.Inventario = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="EnaGas.Cargo")]
	public partial class Cargo : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _idCargo;
		
		private string _cargoUsu;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidCargoChanging(int value);
    partial void OnidCargoChanged();
    partial void OncargoUsuChanging(string value);
    partial void OncargoUsuChanged();
    #endregion
		
		public Cargo()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_idCargo", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int idCargo
		{
			get
			{
				return this._idCargo;
			}
			set
			{
				if ((this._idCargo != value))
				{
					this.OnidCargoChanging(value);
					this.SendPropertyChanging();
					this._idCargo = value;
					this.SendPropertyChanged("idCargo");
					this.OnidCargoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="cargo", Storage="_cargoUsu", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string cargoUsu
		{
			get
			{
				return this._cargoUsu;
			}
			set
			{
				if ((this._cargoUsu != value))
				{
					this.OncargoUsuChanging(value);
					this.SendPropertyChanging();
					this._cargoUsu = value;
					this.SendPropertyChanged("cargoUsu");
					this.OncargoUsuChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591