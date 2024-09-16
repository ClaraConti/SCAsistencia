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

namespace SistemaControlAsistencia
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="BDControlAsistencia")]
	public partial class CAsistenciaDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Definiciones de métodos de extensibilidad
    partial void OnCreated();
    partial void InsertTAlumno(TAlumno instance);
    partial void UpdateTAlumno(TAlumno instance);
    partial void DeleteTAlumno(TAlumno instance);
    partial void InsertTAsistencia(TAsistencia instance);
    partial void UpdateTAsistencia(TAsistencia instance);
    partial void DeleteTAsistencia(TAsistencia instance);
    partial void InsertTAuxiliar(TAuxiliar instance);
    partial void UpdateTAuxiliar(TAuxiliar instance);
    partial void DeleteTAuxiliar(TAuxiliar instance);
    partial void InsertTDocente(TDocente instance);
    partial void UpdateTDocente(TDocente instance);
    partial void DeleteTDocente(TDocente instance);
    partial void InsertTUsuario(TUsuario instance);
    partial void UpdateTUsuario(TUsuario instance);
    partial void DeleteTUsuario(TUsuario instance);
    #endregion
		
		public CAsistenciaDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["BDControlAsistenciaConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public CAsistenciaDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public CAsistenciaDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public CAsistenciaDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public CAsistenciaDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<TAlumno> TAlumno
		{
			get
			{
				return this.GetTable<TAlumno>();
			}
		}
		
		public System.Data.Linq.Table<TAsistencia> TAsistencia
		{
			get
			{
				return this.GetTable<TAsistencia>();
			}
		}
		
		public System.Data.Linq.Table<TAuxiliar> TAuxiliar
		{
			get
			{
				return this.GetTable<TAuxiliar>();
			}
		}
		
		public System.Data.Linq.Table<TDocente> TDocente
		{
			get
			{
				return this.GetTable<TDocente>();
			}
		}
		
		public System.Data.Linq.Table<TUsuario> TUsuario
		{
			get
			{
				return this.GetTable<TUsuario>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.TAlumno")]
	public partial class TAlumno : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _IdAlumno;
		
		private string _Nombre;
		
		private string _Telefono;
		
		private string _CodUsuario;
		
		private EntitySet<TAsistencia> _TAsistencia;
		
		private EntityRef<TUsuario> _TUsuario;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdAlumnoChanging(int value);
    partial void OnIdAlumnoChanged();
    partial void OnNombreChanging(string value);
    partial void OnNombreChanged();
    partial void OnTelefonoChanging(string value);
    partial void OnTelefonoChanged();
    partial void OnCodUsuarioChanging(string value);
    partial void OnCodUsuarioChanged();
    #endregion
		
		public TAlumno()
		{
			this._TAsistencia = new EntitySet<TAsistencia>(new Action<TAsistencia>(this.attach_TAsistencia), new Action<TAsistencia>(this.detach_TAsistencia));
			this._TUsuario = default(EntityRef<TUsuario>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdAlumno", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int IdAlumno
		{
			get
			{
				return this._IdAlumno;
			}
			set
			{
				if ((this._IdAlumno != value))
				{
					this.OnIdAlumnoChanging(value);
					this.SendPropertyChanging();
					this._IdAlumno = value;
					this.SendPropertyChanged("IdAlumno");
					this.OnIdAlumnoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Nombre", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string Nombre
		{
			get
			{
				return this._Nombre;
			}
			set
			{
				if ((this._Nombre != value))
				{
					this.OnNombreChanging(value);
					this.SendPropertyChanging();
					this._Nombre = value;
					this.SendPropertyChanged("Nombre");
					this.OnNombreChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Telefono", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
		public string Telefono
		{
			get
			{
				return this._Telefono;
			}
			set
			{
				if ((this._Telefono != value))
				{
					this.OnTelefonoChanging(value);
					this.SendPropertyChanging();
					this._Telefono = value;
					this.SendPropertyChanged("Telefono");
					this.OnTelefonoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CodUsuario", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string CodUsuario
		{
			get
			{
				return this._CodUsuario;
			}
			set
			{
				if ((this._CodUsuario != value))
				{
					if (this._TUsuario.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnCodUsuarioChanging(value);
					this.SendPropertyChanging();
					this._CodUsuario = value;
					this.SendPropertyChanged("CodUsuario");
					this.OnCodUsuarioChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="TAlumno_TAsistencia", Storage="_TAsistencia", ThisKey="IdAlumno", OtherKey="IdAlumno")]
		public EntitySet<TAsistencia> TAsistencia
		{
			get
			{
				return this._TAsistencia;
			}
			set
			{
				this._TAsistencia.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="TUsuario_TAlumno", Storage="_TUsuario", ThisKey="CodUsuario", OtherKey="CodUsuario", IsForeignKey=true)]
		public TUsuario TUsuario
		{
			get
			{
				return this._TUsuario.Entity;
			}
			set
			{
				TUsuario previousValue = this._TUsuario.Entity;
				if (((previousValue != value) 
							|| (this._TUsuario.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._TUsuario.Entity = null;
						previousValue.TAlumno.Remove(this);
					}
					this._TUsuario.Entity = value;
					if ((value != null))
					{
						value.TAlumno.Add(this);
						this._CodUsuario = value.CodUsuario;
					}
					else
					{
						this._CodUsuario = default(string);
					}
					this.SendPropertyChanged("TUsuario");
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
		
		private void attach_TAsistencia(TAsistencia entity)
		{
			this.SendPropertyChanging();
			entity.TAlumno = this;
		}
		
		private void detach_TAsistencia(TAsistencia entity)
		{
			this.SendPropertyChanging();
			entity.TAlumno = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.TAsistencia")]
	public partial class TAsistencia : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _IdAsistencia;
		
		private int _IdAlumno;
		
		private System.DateTime _Fecha;
		
		private string _Estado;
		
		private EntityRef<TAlumno> _TAlumno;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdAsistenciaChanging(int value);
    partial void OnIdAsistenciaChanged();
    partial void OnIdAlumnoChanging(int value);
    partial void OnIdAlumnoChanged();
    partial void OnFechaChanging(System.DateTime value);
    partial void OnFechaChanged();
    partial void OnEstadoChanging(string value);
    partial void OnEstadoChanged();
    #endregion
		
		public TAsistencia()
		{
			this._TAlumno = default(EntityRef<TAlumno>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdAsistencia", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int IdAsistencia
		{
			get
			{
				return this._IdAsistencia;
			}
			set
			{
				if ((this._IdAsistencia != value))
				{
					this.OnIdAsistenciaChanging(value);
					this.SendPropertyChanging();
					this._IdAsistencia = value;
					this.SendPropertyChanged("IdAsistencia");
					this.OnIdAsistenciaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdAlumno", DbType="Int NOT NULL")]
		public int IdAlumno
		{
			get
			{
				return this._IdAlumno;
			}
			set
			{
				if ((this._IdAlumno != value))
				{
					if (this._TAlumno.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnIdAlumnoChanging(value);
					this.SendPropertyChanging();
					this._IdAlumno = value;
					this.SendPropertyChanged("IdAlumno");
					this.OnIdAlumnoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Fecha", DbType="Date NOT NULL")]
		public System.DateTime Fecha
		{
			get
			{
				return this._Fecha;
			}
			set
			{
				if ((this._Fecha != value))
				{
					this.OnFechaChanging(value);
					this.SendPropertyChanging();
					this._Fecha = value;
					this.SendPropertyChanged("Fecha");
					this.OnFechaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Estado", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
		public string Estado
		{
			get
			{
				return this._Estado;
			}
			set
			{
				if ((this._Estado != value))
				{
					this.OnEstadoChanging(value);
					this.SendPropertyChanging();
					this._Estado = value;
					this.SendPropertyChanged("Estado");
					this.OnEstadoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="TAlumno_TAsistencia", Storage="_TAlumno", ThisKey="IdAlumno", OtherKey="IdAlumno", IsForeignKey=true)]
		public TAlumno TAlumno
		{
			get
			{
				return this._TAlumno.Entity;
			}
			set
			{
				TAlumno previousValue = this._TAlumno.Entity;
				if (((previousValue != value) 
							|| (this._TAlumno.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._TAlumno.Entity = null;
						previousValue.TAsistencia.Remove(this);
					}
					this._TAlumno.Entity = value;
					if ((value != null))
					{
						value.TAsistencia.Add(this);
						this._IdAlumno = value.IdAlumno;
					}
					else
					{
						this._IdAlumno = default(int);
					}
					this.SendPropertyChanged("TAlumno");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.TAuxiliar")]
	public partial class TAuxiliar : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _IdAuxiliar;
		
		private string _Nombre;
		
		private string _Telefono;
		
		private string _CodUsuario;
		
		private EntityRef<TUsuario> _TUsuario;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdAuxiliarChanging(int value);
    partial void OnIdAuxiliarChanged();
    partial void OnNombreChanging(string value);
    partial void OnNombreChanged();
    partial void OnTelefonoChanging(string value);
    partial void OnTelefonoChanged();
    partial void OnCodUsuarioChanging(string value);
    partial void OnCodUsuarioChanged();
    #endregion
		
		public TAuxiliar()
		{
			this._TUsuario = default(EntityRef<TUsuario>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdAuxiliar", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int IdAuxiliar
		{
			get
			{
				return this._IdAuxiliar;
			}
			set
			{
				if ((this._IdAuxiliar != value))
				{
					this.OnIdAuxiliarChanging(value);
					this.SendPropertyChanging();
					this._IdAuxiliar = value;
					this.SendPropertyChanged("IdAuxiliar");
					this.OnIdAuxiliarChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Nombre", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string Nombre
		{
			get
			{
				return this._Nombre;
			}
			set
			{
				if ((this._Nombre != value))
				{
					this.OnNombreChanging(value);
					this.SendPropertyChanging();
					this._Nombre = value;
					this.SendPropertyChanged("Nombre");
					this.OnNombreChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Telefono", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
		public string Telefono
		{
			get
			{
				return this._Telefono;
			}
			set
			{
				if ((this._Telefono != value))
				{
					this.OnTelefonoChanging(value);
					this.SendPropertyChanging();
					this._Telefono = value;
					this.SendPropertyChanged("Telefono");
					this.OnTelefonoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CodUsuario", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string CodUsuario
		{
			get
			{
				return this._CodUsuario;
			}
			set
			{
				if ((this._CodUsuario != value))
				{
					if (this._TUsuario.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnCodUsuarioChanging(value);
					this.SendPropertyChanging();
					this._CodUsuario = value;
					this.SendPropertyChanged("CodUsuario");
					this.OnCodUsuarioChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="TUsuario_TAuxiliar", Storage="_TUsuario", ThisKey="CodUsuario", OtherKey="CodUsuario", IsForeignKey=true)]
		public TUsuario TUsuario
		{
			get
			{
				return this._TUsuario.Entity;
			}
			set
			{
				TUsuario previousValue = this._TUsuario.Entity;
				if (((previousValue != value) 
							|| (this._TUsuario.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._TUsuario.Entity = null;
						previousValue.TAuxiliar.Remove(this);
					}
					this._TUsuario.Entity = value;
					if ((value != null))
					{
						value.TAuxiliar.Add(this);
						this._CodUsuario = value.CodUsuario;
					}
					else
					{
						this._CodUsuario = default(string);
					}
					this.SendPropertyChanged("TUsuario");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.TDocente")]
	public partial class TDocente : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _IdDocente;
		
		private string _Nombre;
		
		private string _Telefono;
		
		private string _CodUsuario;
		
		private EntityRef<TUsuario> _TUsuario;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdDocenteChanging(int value);
    partial void OnIdDocenteChanged();
    partial void OnNombreChanging(string value);
    partial void OnNombreChanged();
    partial void OnTelefonoChanging(string value);
    partial void OnTelefonoChanged();
    partial void OnCodUsuarioChanging(string value);
    partial void OnCodUsuarioChanged();
    #endregion
		
		public TDocente()
		{
			this._TUsuario = default(EntityRef<TUsuario>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdDocente", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int IdDocente
		{
			get
			{
				return this._IdDocente;
			}
			set
			{
				if ((this._IdDocente != value))
				{
					this.OnIdDocenteChanging(value);
					this.SendPropertyChanging();
					this._IdDocente = value;
					this.SendPropertyChanged("IdDocente");
					this.OnIdDocenteChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Nombre", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string Nombre
		{
			get
			{
				return this._Nombre;
			}
			set
			{
				if ((this._Nombre != value))
				{
					this.OnNombreChanging(value);
					this.SendPropertyChanging();
					this._Nombre = value;
					this.SendPropertyChanged("Nombre");
					this.OnNombreChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Telefono", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
		public string Telefono
		{
			get
			{
				return this._Telefono;
			}
			set
			{
				if ((this._Telefono != value))
				{
					this.OnTelefonoChanging(value);
					this.SendPropertyChanging();
					this._Telefono = value;
					this.SendPropertyChanged("Telefono");
					this.OnTelefonoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CodUsuario", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string CodUsuario
		{
			get
			{
				return this._CodUsuario;
			}
			set
			{
				if ((this._CodUsuario != value))
				{
					if (this._TUsuario.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnCodUsuarioChanging(value);
					this.SendPropertyChanging();
					this._CodUsuario = value;
					this.SendPropertyChanged("CodUsuario");
					this.OnCodUsuarioChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="TUsuario_TDocente", Storage="_TUsuario", ThisKey="CodUsuario", OtherKey="CodUsuario", IsForeignKey=true)]
		public TUsuario TUsuario
		{
			get
			{
				return this._TUsuario.Entity;
			}
			set
			{
				TUsuario previousValue = this._TUsuario.Entity;
				if (((previousValue != value) 
							|| (this._TUsuario.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._TUsuario.Entity = null;
						previousValue.TDocente.Remove(this);
					}
					this._TUsuario.Entity = value;
					if ((value != null))
					{
						value.TDocente.Add(this);
						this._CodUsuario = value.CodUsuario;
					}
					else
					{
						this._CodUsuario = default(string);
					}
					this.SendPropertyChanged("TUsuario");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.TUsuario")]
	public partial class TUsuario : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _CodUsuario;
		
		private System.Data.Linq.Binary _Contrasena;
		
		private EntitySet<TAlumno> _TAlumno;
		
		private EntitySet<TAuxiliar> _TAuxiliar;
		
		private EntitySet<TDocente> _TDocente;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnCodUsuarioChanging(string value);
    partial void OnCodUsuarioChanged();
    partial void OnContrasenaChanging(System.Data.Linq.Binary value);
    partial void OnContrasenaChanged();
    #endregion
		
		public TUsuario()
		{
			this._TAlumno = new EntitySet<TAlumno>(new Action<TAlumno>(this.attach_TAlumno), new Action<TAlumno>(this.detach_TAlumno));
			this._TAuxiliar = new EntitySet<TAuxiliar>(new Action<TAuxiliar>(this.attach_TAuxiliar), new Action<TAuxiliar>(this.detach_TAuxiliar));
			this._TDocente = new EntitySet<TDocente>(new Action<TDocente>(this.attach_TDocente), new Action<TDocente>(this.detach_TDocente));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CodUsuario", DbType="VarChar(50) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string CodUsuario
		{
			get
			{
				return this._CodUsuario;
			}
			set
			{
				if ((this._CodUsuario != value))
				{
					this.OnCodUsuarioChanging(value);
					this.SendPropertyChanging();
					this._CodUsuario = value;
					this.SendPropertyChanged("CodUsuario");
					this.OnCodUsuarioChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Contrasena", DbType="VarBinary(8000) NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
		public System.Data.Linq.Binary Contrasena
		{
			get
			{
				return this._Contrasena;
			}
			set
			{
				if ((this._Contrasena != value))
				{
					this.OnContrasenaChanging(value);
					this.SendPropertyChanging();
					this._Contrasena = value;
					this.SendPropertyChanged("Contrasena");
					this.OnContrasenaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="TUsuario_TAlumno", Storage="_TAlumno", ThisKey="CodUsuario", OtherKey="CodUsuario")]
		public EntitySet<TAlumno> TAlumno
		{
			get
			{
				return this._TAlumno;
			}
			set
			{
				this._TAlumno.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="TUsuario_TAuxiliar", Storage="_TAuxiliar", ThisKey="CodUsuario", OtherKey="CodUsuario")]
		public EntitySet<TAuxiliar> TAuxiliar
		{
			get
			{
				return this._TAuxiliar;
			}
			set
			{
				this._TAuxiliar.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="TUsuario_TDocente", Storage="_TDocente", ThisKey="CodUsuario", OtherKey="CodUsuario")]
		public EntitySet<TDocente> TDocente
		{
			get
			{
				return this._TDocente;
			}
			set
			{
				this._TDocente.Assign(value);
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
		
		private void attach_TAlumno(TAlumno entity)
		{
			this.SendPropertyChanging();
			entity.TUsuario = this;
		}
		
		private void detach_TAlumno(TAlumno entity)
		{
			this.SendPropertyChanging();
			entity.TUsuario = null;
		}
		
		private void attach_TAuxiliar(TAuxiliar entity)
		{
			this.SendPropertyChanging();
			entity.TUsuario = this;
		}
		
		private void detach_TAuxiliar(TAuxiliar entity)
		{
			this.SendPropertyChanging();
			entity.TUsuario = null;
		}
		
		private void attach_TDocente(TDocente entity)
		{
			this.SendPropertyChanging();
			entity.TUsuario = this;
		}
		
		private void detach_TDocente(TDocente entity)
		{
			this.SendPropertyChanging();
			entity.TUsuario = null;
		}
	}
}
#pragma warning restore 1591
