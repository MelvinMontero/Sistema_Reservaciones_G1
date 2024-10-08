//---------------------------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated by T4Model template for T4 (https://github.com/linq2db/linq2db).
//    Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//---------------------------------------------------------------------------------------------------

#pragma warning disable 1573, 1591

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

using LinqToDB;
using LinqToDB.Common;
using LinqToDB.Configuration;
using LinqToDB.Data;
using LinqToDB.Mapping;

namespace DataModels
{
	/// <summary>
	/// Database       : PV_ProyectoFinal
	/// Data Source    : localhost\SQLEXPRESS01
	/// Server Version : 16.00.1000
	/// </summary>
	public partial class PvProyectoFinalDB : LinqToDB.Data.DataConnection
	{
		public ITable<Bitacora>    Bitacoras    { get { return this.GetTable<Bitacora>(); } }
		public ITable<Habitacion>  Habitacions  { get { return this.GetTable<Habitacion>(); } }
		public ITable<Hotel>       Hotels       { get { return this.GetTable<Hotel>(); } }
		public ITable<Persona>     Personas     { get { return this.GetTable<Persona>(); } }
		public ITable<Reservacion> Reservacions { get { return this.GetTable<Reservacion>(); } }

		public PvProyectoFinalDB()
		{
			InitDataContext();
			InitMappingSchema();
		}

		public PvProyectoFinalDB(string configuration)
			: base(configuration)
		{
			InitDataContext();
			InitMappingSchema();
		}

		public PvProyectoFinalDB(DataOptions options)
			: base(options)
		{
			InitDataContext();
			InitMappingSchema();
		}

		public PvProyectoFinalDB(DataOptions<PvProyectoFinalDB> options)
			: base(options.Options)
		{
			InitDataContext();
			InitMappingSchema();
		}

		partial void InitDataContext  ();
		partial void InitMappingSchema();
	}

	[Table(Schema="dbo", Name="Bitacora")]
	public partial class Bitacora
	{
		[Column("idBitacora"),      PrimaryKey, Identity] public int      IdBitacora      { get; set; } // int
		[Column("idReservacion"),   NotNull             ] public int      IdReservacion   { get; set; } // int
		[Column("idPersona"),       NotNull             ] public int      IdPersona       { get; set; } // int
		[Column("accionRealizada"), NotNull             ] public string   AccionRealizada { get; set; } // varchar(25)
		[Column("fechaDeLaAccion"), NotNull             ] public DateTime FechaDeLaAccion { get; set; } // datetime

		#region Associations

		/// <summary>
		/// FK_Bitacora_Persona (dbo.Persona)
		/// </summary>
		[Association(ThisKey="IdPersona", OtherKey="IdPersona", CanBeNull=false)]
		public Persona Persona { get; set; }

		/// <summary>
		/// FK_Bitacora_Reservacion (dbo.Reservacion)
		/// </summary>
		[Association(ThisKey="IdReservacion", OtherKey="IdReservacion", CanBeNull=false)]
		public Reservacion Reservacion { get; set; }

		#endregion
	}

	[Table(Schema="dbo", Name="Habitacion")]
	public partial class Habitacion
	{
		[Column("idHabitacion"),     PrimaryKey, Identity] public int    IdHabitacion     { get; set; } // int
		[Column("idHotel"),          NotNull             ] public int    IdHotel          { get; set; } // int
		[Column("numeroHabitacion"), NotNull             ] public string NumeroHabitacion { get; set; } // varchar(10)
		[Column("capacidadMaxima"),  NotNull             ] public int    CapacidadMaxima  { get; set; } // int
		[Column("descripcion"),      NotNull             ] public string Descripcion      { get; set; } // varchar(500)
		[Column("estado"),           NotNull             ] public char   Estado           { get; set; } // varchar(1)

		#region Associations

		/// <summary>
		/// FK_Habitacion_Hotel (dbo.Hotel)
		/// </summary>
		[Association(ThisKey="IdHotel", OtherKey="IdHotel", CanBeNull=false)]
		public Hotel Hotel { get; set; }

		/// <summary>
		/// FK_Reservacion_Habitacion_BackReference (dbo.Reservacion)
		/// </summary>
		[Association(ThisKey="IdHabitacion", OtherKey="IdHabitacion", CanBeNull=true)]
		public IEnumerable<Reservacion> Reservacions { get; set; }

		#endregion
	}

	[Table(Schema="dbo", Name="Hotel")]
	public partial class Hotel
	{
		[Column("idHotel"),            PrimaryKey,  Identity] public int     IdHotel            { get; set; } // int
		[Column("nombre"),             NotNull              ] public string  Nombre             { get; set; } // varchar(150)
		[Column("direccion"),             Nullable          ] public string  Direccion          { get; set; } // varchar(500)
		[Column("costoPorCadaAdulto"), NotNull              ] public decimal CostoPorCadaAdulto { get; set; } // numeric(10, 2)
		[Column("costoPorCadaNinho"),  NotNull              ] public decimal CostoPorCadaNinho  { get; set; } // numeric(10, 2)

		#region Associations

		/// <summary>
		/// FK_Habitacion_Hotel_BackReference (dbo.Habitacion)
		/// </summary>
		[Association(ThisKey="IdHotel", OtherKey="IdHotel", CanBeNull=true)]
		public IEnumerable<Habitacion> Habitacions { get; set; }

		#endregion
	}

	[Table(Schema="dbo", Name="Persona")]
	public partial class Persona
	{
		[Column("idPersona"),      PrimaryKey, Identity] public int    IdPersona      { get; set; } // int
		[Column("nombreCompleto"), NotNull             ] public string NombreCompleto { get; set; } // varchar(250)
		[Column("email"),          NotNull             ] public string Email          { get; set; } // varchar(150)
		[Column("clave"),          NotNull             ] public string Clave          { get; set; } // varchar(15)
		[Column("esEmpleado"),     NotNull             ] public bool   EsEmpleado     { get; set; } // bit
		[Column("estado"),         NotNull             ] public char   Estado         { get; set; } // varchar(1)

		#region Associations

		/// <summary>
		/// FK_Bitacora_Persona_BackReference (dbo.Bitacora)
		/// </summary>
		[Association(ThisKey="IdPersona", OtherKey="IdPersona", CanBeNull=true)]
		public IEnumerable<Bitacora> Bitacoras { get; set; }

		/// <summary>
		/// FK_Reservacion_Persona_BackReference (dbo.Reservacion)
		/// </summary>
		[Association(ThisKey="IdPersona", OtherKey="IdPersona", CanBeNull=true)]
		public IEnumerable<Reservacion> Reservacions { get; set; }

		#endregion
	}

	[Table(Schema="dbo", Name="Reservacion")]
	public partial class Reservacion
	{
		[Column("idReservacion"),        PrimaryKey,  Identity] public int       IdReservacion        { get; set; } // int
		[Column("idPersona"),            NotNull              ] public int       IdPersona            { get; set; } // int
		[Column("idHabitacion"),         NotNull              ] public int       IdHabitacion         { get; set; } // int
		[Column("fechaEntrada"),         NotNull              ] public DateTime  FechaEntrada         { get; set; } // datetime
		[Column("fechaSalida"),          NotNull              ] public DateTime  FechaSalida          { get; set; } // datetime
		[Column("numeroAdultos"),        NotNull              ] public int       NumeroAdultos        { get; set; } // int
		[Column("numeroNinhos"),         NotNull              ] public int       NumeroNinhos         { get; set; } // int
		[Column("totalDiasReservacion"), NotNull              ] public int       TotalDiasReservacion { get; set; } // int
		[Column("costoPorCadaAdulto"),   NotNull              ] public decimal   CostoPorCadaAdulto   { get; set; } // numeric(10, 2)
		[Column("costoPorCadaNinho"),    NotNull              ] public decimal   CostoPorCadaNinho    { get; set; } // numeric(10, 2)
		[Column("costoTotal"),           NotNull              ] public decimal   CostoTotal           { get; set; } // numeric(14, 2)
		[Column("fechaCreacion"),        NotNull              ] public DateTime  FechaCreacion        { get; set; } // datetime
		[Column("fechaModificacion"),       Nullable          ] public DateTime? FechaModificacion    { get; set; } // datetime
		[Column("estado"),               NotNull              ] public char      Estado               { get; set; } // varchar(1)

		#region Associations

		/// <summary>
		/// FK_Bitacora_Reservacion_BackReference (dbo.Bitacora)
		/// </summary>
		[Association(ThisKey="IdReservacion", OtherKey="IdReservacion", CanBeNull=true)]
		public IEnumerable<Bitacora> Bitacoras { get; set; }

		/// <summary>
		/// FK_Reservacion_Habitacion (dbo.Habitacion)
		/// </summary>
		[Association(ThisKey="IdHabitacion", OtherKey="IdHabitacion", CanBeNull=false)]
		public Habitacion Habitacion { get; set; }

		/// <summary>
		/// FK_Reservacion_Persona (dbo.Persona)
		/// </summary>
		[Association(ThisKey="IdPersona", OtherKey="IdPersona", CanBeNull=false)]
		public Persona Persona { get; set; }

		#endregion
	}

	public static partial class PvProyectoFinalDBStoredProcedures
	{
		#region EditarHabitacion

		public static IEnumerable<EditarHabitacionResult> EditarHabitacion(this PvProyectoFinalDB dataConnection, int? @idHabitacion, string @numeroHabitacion, int? @capacidadMaxima, string @descripcion)
		{
			var parameters = new []
			{
				new DataParameter("@idHabitacion",     @idHabitacion,     LinqToDB.DataType.Int32),
				new DataParameter("@numeroHabitacion", @numeroHabitacion, LinqToDB.DataType.NVarChar)
				{
					Size = 10
				},
				new DataParameter("@capacidadMaxima",  @capacidadMaxima,  LinqToDB.DataType.Int32),
				new DataParameter("@descripcion",      @descripcion,      LinqToDB.DataType.NVarChar)
				{
					Size = 500
				}
			};

			return dataConnection.QueryProc<EditarHabitacionResult>("[dbo].[EditarHabitacion]", parameters);
		}

		public partial class EditarHabitacionResult
		{
			public string Mensaje { get; set; }
		}

		#endregion

		#region EliminarHabitacion

		public static int EliminarHabitacion(this PvProyectoFinalDB dataConnection, int? @HotelId, string @NumeroHabitacion)
		{
			var parameters = new []
			{
				new DataParameter("@HotelId",          @HotelId,          LinqToDB.DataType.Int32),
				new DataParameter("@NumeroHabitacion", @NumeroHabitacion, LinqToDB.DataType.NVarChar)
				{
					Size = 50
				}
			};

			return dataConnection.ExecuteProc("[dbo].[EliminarHabitacion]", parameters);
		}

		#endregion

		#region InactivarHabitacion

		public static IEnumerable<InactivarHabitacionResult> InactivarHabitacion(this PvProyectoFinalDB dataConnection, int? @idHabitacion)
		{
			var parameters = new []
			{
				new DataParameter("@idHabitacion", @idHabitacion, LinqToDB.DataType.Int32)
			};

			return dataConnection.QueryProc<InactivarHabitacionResult>("[dbo].[InactivarHabitacion]", parameters);
		}

		public partial class InactivarHabitacionResult
		{
			public string Mensaje { get; set; }
		}

		#endregion

		#region SpAutenticarUsuario

		public static IEnumerable<Persona> SpAutenticarUsuario(this PvProyectoFinalDB dataConnection, string @email, string @clave)
		{
			var parameters = new []
			{
				new DataParameter("@email", @email, LinqToDB.DataType.VarChar)
				{
					Size = 150
				},
				new DataParameter("@clave", @clave, LinqToDB.DataType.VarChar)
				{
					Size = 15
				}
			};

			return dataConnection.QueryProc<Persona>("[dbo].[sp_Autenticar_Usuario]", parameters);
		}

		#endregion

		#region SpCancelarReservacion

		public static int SpCancelarReservacion(this PvProyectoFinalDB dataConnection, int? @idReservacion, int? @idPersona)
		{
			var parameters = new []
			{
				new DataParameter("@idReservacion", @idReservacion, LinqToDB.DataType.Int32),
				new DataParameter("@idPersona",     @idPersona,     LinqToDB.DataType.Int32)
			};

			return dataConnection.ExecuteProc("[dbo].[sp_CancelarReservacion]", parameters);
		}

		#endregion

		#region SpCargartodoslosHoteles

		public static IEnumerable<SpCargartodoslosHotelesResult> SpCargartodoslosHoteles(this PvProyectoFinalDB dataConnection)
		{
			return dataConnection.QueryProc<SpCargartodoslosHotelesResult>("[dbo].[SpCargartodoslosHoteles]");
		}

		public partial class SpCargartodoslosHotelesResult
		{
			public string Nombre { get; set; }
		}

		#endregion

		#region SpConsultarBitacora

		public static IEnumerable<SpConsultarBitacoraResult> SpConsultarBitacora(this PvProyectoFinalDB dataConnection, int? @idReservacion)
		{
			var parameters = new []
			{
				new DataParameter("@idReservacion", @idReservacion, LinqToDB.DataType.Int32)
			};

			return dataConnection.QueryProc<SpConsultarBitacoraResult>("[dbo].[sp_ConsultarBitacora]", parameters);
		}

		public partial class SpConsultarBitacoraResult
		{
			[Column("idBitacora")     ] public int      IdBitacora      { get; set; }
			[Column("fechaDeLaAccion")] public DateTime FechaDeLaAccion { get; set; }
			[Column("accionRealizada")] public string   AccionRealizada { get; set; }
			[Column("nombreCompleto") ] public string   NombreCompleto  { get; set; }
		}

		#endregion

		#region SpConsultarHabitaciones

		public static IEnumerable<SpConsultarHabitacionesResult> SpConsultarHabitaciones(this PvProyectoFinalDB dataConnection, int? @IdHabitacion)
		{
			var parameters = new []
			{
				new DataParameter("@IdHabitacion", @IdHabitacion, LinqToDB.DataType.Int32)
			};

			return dataConnection.QueryProc<SpConsultarHabitacionesResult>("[dbo].[spConsultarHabitaciones]", parameters);
		}

		public partial class SpConsultarHabitacionesResult
		{
			public int    IdHabitacion     { get; set; }
			public string Nombre           { get; set; }
			public string NumeroHabitacion { get; set; }
			public int    CapacidadMaxima  { get; set; }
			public string Descripcion      { get; set; }
			public char   Estado           { get; set; }
		}

		#endregion

		#region SpConsultarHabitacionesPorId

		public static IEnumerable<SpConsultarHabitacionesPorIdResult> SpConsultarHabitacionesPorId(this PvProyectoFinalDB dataConnection, int? @IdHotel, int? @CapacidadRequerida)
		{
			var parameters = new []
			{
				new DataParameter("@IdHotel",            @IdHotel,            LinqToDB.DataType.Int32),
				new DataParameter("@CapacidadRequerida", @CapacidadRequerida, LinqToDB.DataType.Int32)
			};

			return dataConnection.QueryProc<SpConsultarHabitacionesPorIdResult>("[dbo].[spConsultarHabitacionesPorId]", parameters);
		}

		public partial class SpConsultarHabitacionesPorIdResult
		{
			[Column("idHabitacion")      ] public int     IdHabitacion       { get; set; }
			[Column("numeroHabitacion")  ] public string  NumeroHabitacion   { get; set; }
			[Column("capacidadMaxima")   ] public int     CapacidadMaxima    { get; set; }
			[Column("descripcion")       ] public string  Descripcion        { get; set; }
			[Column("estado")            ] public char    Estado             { get; set; }
			[Column("costoPorCadaAdulto")] public decimal CostoPorCadaAdulto { get; set; }
			[Column("costoPorCadaNinho") ] public decimal CostoPorCadaNinho  { get; set; }
		}

		#endregion

		#region SpConsultarHabitacionesPorNumeroHabitacion

		public static IEnumerable<SpConsultarHabitacionesPorNumeroHabitacionResult> SpConsultarHabitacionesPorNumeroHabitacion(this PvProyectoFinalDB dataConnection, string @numeroHabitacion, int? @idHotel)
		{
			var parameters = new []
			{
				new DataParameter("@numeroHabitacion", @numeroHabitacion, LinqToDB.DataType.VarChar)
				{
					Size = 10
				},
				new DataParameter("@idHotel",          @idHotel,          LinqToDB.DataType.Int32)
			};

			return dataConnection.QueryProc<SpConsultarHabitacionesPorNumeroHabitacionResult>("[dbo].[spConsultarHabitacionesPorNumeroHabitacion]", parameters);
		}

		public partial class SpConsultarHabitacionesPorNumeroHabitacionResult
		{
			[Column("numeroHabitacion")] public string NumeroHabitacion { get; set; }
		}

		#endregion

		#region SpConsultarHotel

		public static IEnumerable<Hotel> SpConsultarHotel(this PvProyectoFinalDB dataConnection)
		{
			return dataConnection.QueryProc<Hotel>("[dbo].[spConsultarHotel]");
		}

		#endregion

		#region SpConsultarListaHabitaciones

		public static IEnumerable<SpConsultarListaHabitacionesResult> SpConsultarListaHabitaciones(this PvProyectoFinalDB dataConnection)
		{
			return dataConnection.QueryProc<SpConsultarListaHabitacionesResult>("[dbo].[SpConsultarListaHabitaciones]");
		}

		public partial class SpConsultarListaHabitacionesResult
		{
			public int    ID               { get; set; }
			public int    Hotel            { get; set; }
			public string NumeroHabitacion { get; set; }
			public int    CapacidadMaxima  { get; set; }
			public string Estado           { get; set; }
		}

		#endregion

		#region SpConsultarPersona

		public static IEnumerable<Persona> SpConsultarPersona(this PvProyectoFinalDB dataConnection)
		{
			return dataConnection.QueryProc<Persona>("[dbo].[spConsultarPersona]");
		}

		#endregion

		#region SpConsultarReservacion

		public static IEnumerable<SpConsultarReservacionResult> SpConsultarReservacion(this PvProyectoFinalDB dataConnection, int? @idReservacion)
		{
			var parameters = new []
			{
				new DataParameter("@idReservacion", @idReservacion, LinqToDB.DataType.Int32)
			};

			return dataConnection.QueryProc<SpConsultarReservacionResult>("[dbo].[sp_ConsultarReservacion]", parameters);
		}

		public partial class SpConsultarReservacionResult
		{
			[Column("idReservacion")       ] public int       IdReservacion        { get; set; }
			[Column("idPersona")           ] public int       IdPersona            { get; set; }
			[Column("idHotel")             ] public int       IdHotel              { get; set; }
			[Column("nombre")              ] public string    Nombre               { get; set; }
			[Column("numeroHabitacion")    ] public string    NumeroHabitacion     { get; set; }
			[Column("capacidadMaxima")     ] public int       CapacidadMaxima      { get; set; }
			[Column("nombreCompleto")      ] public string    NombreCompleto       { get; set; }
			[Column("fechaEntrada")        ] public DateTime? FechaEntrada         { get; set; }
			[Column("fechaSalida")         ] public DateTime? FechaSalida          { get; set; }
			[Column("totalDiasReservacion")] public int       TotalDiasReservacion { get; set; }
			[Column("numeroNinhos")        ] public int       NumeroNinhos         { get; set; }
			[Column("numeroAdultos")       ] public int       NumeroAdultos        { get; set; }
			[Column("costoTotal")          ] public decimal   CostoTotal           { get; set; }
			[Column("estado")              ] public char      Estado               { get; set; }
		}

		#endregion

		#region SpCrearBitacora

		public static int SpCrearBitacora(this PvProyectoFinalDB dataConnection, int? @idPersona, string @accionRealizada)
		{
			var parameters = new []
			{
				new DataParameter("@idPersona",       @idPersona,       LinqToDB.DataType.Int32),
				new DataParameter("@accionRealizada", @accionRealizada, LinqToDB.DataType.VarChar)
				{
					Size = 25
				}
			};

			return dataConnection.ExecuteProc("[dbo].[spCrearBitacora]", parameters);
		}

		#endregion

		#region SpCrearHabitacion

		public static int SpCrearHabitacion(this PvProyectoFinalDB dataConnection, int? @HotelId, string @NumeroHabitacion, int? @CapacidadMaxima, string @Descripcion)
		{
			var parameters = new []
			{
				new DataParameter("@HotelId",          @HotelId,          LinqToDB.DataType.Int32),
				new DataParameter("@NumeroHabitacion", @NumeroHabitacion, LinqToDB.DataType.NVarChar)
				{
					Size = 50
				},
				new DataParameter("@CapacidadMaxima",  @CapacidadMaxima,  LinqToDB.DataType.Int32),
				new DataParameter("@Descripcion",      @Descripcion,      LinqToDB.DataType.NVarChar)
				{
					Size = 500
				}
			};

			return dataConnection.ExecuteProc("[dbo].[SpCrearHabitacion]", parameters);
		}

		#endregion

		#region SpCrearReservacion

		public static int SpCrearReservacion(this PvProyectoFinalDB dataConnection, int? @idPersona, int? @idHabitacion, DateTime? @fechaEntrada, DateTime? @fechaSalida, int? @numeroAdultos, int? @numeroNinhos, int? @totalDiasReservacion, decimal? @costoPorCadaAdulto, decimal? @costoPorCadaNinho, decimal? @costoTotal, DateTime? @fechaCreacion, char? @estado)
		{
			var parameters = new []
			{
				new DataParameter("@idPersona",            @idPersona,            LinqToDB.DataType.Int32),
				new DataParameter("@idHabitacion",         @idHabitacion,         LinqToDB.DataType.Int32),
				new DataParameter("@fechaEntrada",         @fechaEntrada,         LinqToDB.DataType.DateTime),
				new DataParameter("@fechaSalida",          @fechaSalida,          LinqToDB.DataType.DateTime),
				new DataParameter("@numeroAdultos",        @numeroAdultos,        LinqToDB.DataType.Int32),
				new DataParameter("@numeroNinhos",         @numeroNinhos,         LinqToDB.DataType.Int32),
				new DataParameter("@totalDiasReservacion", @totalDiasReservacion, LinqToDB.DataType.Int32),
				new DataParameter("@costoPorCadaAdulto",   @costoPorCadaAdulto,   LinqToDB.DataType.Decimal),
				new DataParameter("@costoPorCadaNinho",    @costoPorCadaNinho,    LinqToDB.DataType.Decimal),
				new DataParameter("@costoTotal",           @costoTotal,           LinqToDB.DataType.Decimal),
				new DataParameter("@fechaCreacion",        @fechaCreacion,        LinqToDB.DataType.DateTime),
				new DataParameter("@estado",               @estado,               LinqToDB.DataType.VarChar)
				{
					Size = 1
				}
			};

			return dataConnection.ExecuteProc("[dbo].[spCrearReservacion]", parameters);
		}

		#endregion

		#region SpGestionarReservaciones

		public static IEnumerable<SpGestionarReservacionesResult> SpGestionarReservaciones(this PvProyectoFinalDB dataConnection)
		{
			return dataConnection.QueryProc<SpGestionarReservacionesResult>("[dbo].[sp_GestionarReservaciones]");
		}

		public partial class SpGestionarReservacionesResult
		{
			[Column("idReservacion") ] public int       IdReservacion  { get; set; }
			[Column("nombreCompleto")] public string    NombreCompleto { get; set; }
			[Column("nombre")        ] public string    Nombre         { get; set; }
			[Column("fechaEntrada")  ] public DateTime? FechaEntrada   { get; set; }
			[Column("fechaSalida")   ] public DateTime? FechaSalida    { get; set; }
			[Column("costoTotal")    ] public decimal   CostoTotal     { get; set; }
			[Column("estado")        ] public char      Estado         { get; set; }
		}

		#endregion

		#region SpMisReservaciones

		public static IEnumerable<SpMisReservacionesResult> SpMisReservaciones(this PvProyectoFinalDB dataConnection, int? @idPersona)
		{
			var parameters = new []
			{
				new DataParameter("@idPersona", @idPersona, LinqToDB.DataType.Int32)
			};

			return dataConnection.QueryProc<SpMisReservacionesResult>("[dbo].[sp_MisReservaciones]", parameters);
		}

		public partial class SpMisReservacionesResult
		{
			[Column("idReservacion")] public int       IdReservacion { get; set; }
			[Column("nombre")       ] public string    Nombre        { get; set; }
			[Column("fechaEntrada") ] public DateTime? FechaEntrada  { get; set; }
			[Column("fechaSalida")  ] public DateTime? FechaSalida   { get; set; }
			[Column("costoTotal")   ] public decimal   CostoTotal    { get; set; }
			[Column("estado")       ] public char      Estado        { get; set; }
		}

		#endregion

		#region SpModificarReservacion

		public static int SpModificarReservacion(this PvProyectoFinalDB dataConnection, int? @idReservacion, DateTime? @fechaEntrada, DateTime? @fechaSalida, int? @numeroAdultos, int? @numeroNinhos, int? @totalDiasReservacion, decimal? @costoPorCadaAdulto, decimal? @costoPorCadaNinho, decimal? @costoTotal, DateTime? @fechaModificacion)
		{
			var parameters = new []
			{
				new DataParameter("@idReservacion",        @idReservacion,        LinqToDB.DataType.Int32),
				new DataParameter("@fechaEntrada",         @fechaEntrada,         LinqToDB.DataType.DateTime),
				new DataParameter("@fechaSalida",          @fechaSalida,          LinqToDB.DataType.DateTime),
				new DataParameter("@numeroAdultos",        @numeroAdultos,        LinqToDB.DataType.Int32),
				new DataParameter("@numeroNinhos",         @numeroNinhos,         LinqToDB.DataType.Int32),
				new DataParameter("@totalDiasReservacion", @totalDiasReservacion, LinqToDB.DataType.Int32),
				new DataParameter("@costoPorCadaAdulto",   @costoPorCadaAdulto,   LinqToDB.DataType.Decimal),
				new DataParameter("@costoPorCadaNinho",    @costoPorCadaNinho,    LinqToDB.DataType.Decimal),
				new DataParameter("@costoTotal",           @costoTotal,           LinqToDB.DataType.Decimal),
				new DataParameter("@fechaModificacion",    @fechaModificacion,    LinqToDB.DataType.DateTime)
			};

			return dataConnection.ExecuteProc("[dbo].[spModificarReservacion]", parameters);
		}

		#endregion
	}

	public static partial class TableExtensions
	{
		public static Bitacora Find(this ITable<Bitacora> table, int IdBitacora)
		{
			return table.FirstOrDefault(t =>
				t.IdBitacora == IdBitacora);
		}

		public static Habitacion Find(this ITable<Habitacion> table, int IdHabitacion)
		{
			return table.FirstOrDefault(t =>
				t.IdHabitacion == IdHabitacion);
		}

		public static Hotel Find(this ITable<Hotel> table, int IdHotel)
		{
			return table.FirstOrDefault(t =>
				t.IdHotel == IdHotel);
		}

		public static Persona Find(this ITable<Persona> table, int IdPersona)
		{
			return table.FirstOrDefault(t =>
				t.IdPersona == IdPersona);
		}

		public static Reservacion Find(this ITable<Reservacion> table, int IdReservacion)
		{
			return table.FirstOrDefault(t =>
				t.IdReservacion == IdReservacion);
		}
	}
}
