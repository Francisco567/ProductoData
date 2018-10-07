-----------------------------------------------------------------------------------------------------------------
--------------------------------------PROYECTO GESTION DE DATOS II-----------------------------------------------
-----------------------------------------------------------------------------------------------------------------

/*Base datos ProdcutoData, esta base de datos tiene como finalidad el registro y control de productos de una 
pequeña tienda , minimarket o bodega*/

-------CARPETAS DONDE SE GUARDARAN LA BASE DE DATOS-------

--Carpetas Disco C:\

xp_create_subdir 'C:\Productos\Principal'
go

xp_create_subdir 'C:\Productos\Establecimiento'
go

xp_create_subdir 'C:\Productos\Almacen'
go

xp_create_subdir 'C:\Productos\Logs'
go

xp_create_subdir 'C:\Productos\Establecimiento'
go

xp_create_subdir 'C:\Productos\Almacen'
go

--Carpetas Disco D:\
xp_create_subdir 'D:\productos\principal'
go

xp_create_subdir 'D:\productos\establecimiento'
go

xp_create_subdir 'D:\productos\almacen'
go

xp_create_subdir 'D:\productos\logs'
go


--------CREACION DE LA BASE DE DATOS Y SUS GRUPOS DE ARCHIVOS-------
if not exists(select * from sys.databases where name='ProductoData')
  Begin
    Create database ProductoData
	  ON PRIMARY
	    (name = 'P1', filename = 'C:\Productos\Principal\P1.mdf',Size=10MB,maxsize=200MB,filegrowth=10MB),
	    (name = 'P2', filename = 'D:\productos\principal\P2.mdf',Size=10MB,maxsize=200MB,filegrowth=10MB),
	  filegroup Establecimiento
	    (name = 'Pr1', filename = 'C:\Productos\Establecimiento\Pr1.ndf',Size=10MB,maxsize=200MB,filegrowth=10MB),
	    (name = 'Pr2', filename = 'D:\productos\establecimiento\Pr2.ndf',Size=10MB,maxsize=200MB,filegrowth=10MB),
	  filegroup Almacen
	    (name = 'A1', filename = 'C:\Productos\Almacen\A1.ndf',Size=10MB,maxsize=200MB,filegrowth=10MB),
	    (name = 'A2', filename = 'D:\productos\almacen\A2.ndf',Size=10MB,maxsize=200MB,filegrowth=10MB)
	  LOG ON
	    (name = 'Log_1', filename = 'C:\Productos\Logs\Log_1.ldf',Size=5MB,maxsize=100MB,filegrowth=10MB),
	    (name = 'Log_2', filename = 'D:\productos\logs\Log_2.ldf',Size=5MB,maxsize=100MB,filegrowth=10MB)
    end
go


--------USO DE LA BASE DE DATOS-------
if exists(select * from sys.databases where name='ProductoData')
    Begin    
		use ProductoData
    End
go

--------CREACION DE ESQUEMAS-------
if not exists (select * from sys.schemas WHERE name = 'Administracion' or name = 'Almacen' or name = 'Externos')
	Begin
		Exec('Create schema Administracion')
		Exec('Create schema Almacen')
		Exec('Create schema Externos')
	End
go


--------TIPOS DE DATOS DEFINIDOS POR EL USUARIO-------
if not exists (select * from sys.types where name = 'Codigo' or name = 'Texto' or  name = 'TextoNumerico')
    Begin
        Create type Codigo from nchar(8) not null
		Create type Texto from varchar(100) not null
        Create type TextoNumerico from nvarchar(200) not null
    End
go

--------FUNCIONES DE PARTICION-------
if not exists (select * from sys.partition_functions where name = 'EstablecimientoFuncionParticion'  or name = 'AlmacenFuncionParticion' )
    Begin
       Create partition function EstablecimientoFuncionParticion (nchar(8))
	           as range right for values ('D','G','J') 
       Create partition function AlmacenFuncionParticion (nchar(8))
	           as range for values ('E','H','k')
    end
go

--------ESQUEMAS DE PARTICION-------
if not exists (select * from sys.partition_schemes where name = 'EstablecimientoEsquemaParticion'  
               or name = 'AlmacenEsquemaParticion ' )
  Begin
    exec(' Create partition scheme EstablecimientoEsquemaParticion As partition EstablecimientoFuncionParticion 
	        to ([Primary], Establecimiento,[Primary], Establecimiento)')
     exec('Create partition scheme AlmacenEsquemaParticion As partition AlmacenFuncionParticion 
	        to (Establecimiento,Almacen,Establecimiento,Almacen)')
	end
go

--------TABLAS DE LA BASE DE DATOS-------

--TABLA CATEGORIA
if not exists (select * from Information_Schema.Tables WHERE TABLE_SCHEMA = 'Almacen' and TABLE_NAME='Categoria')
Begin
    create table Almacen.Categoria
    (CategoriaCodigo Codigo,
    CategoriaNombre Texto not null,
    CategoriaDescripcion varchar(200)not null,
    constraint CategoriaCodigoPK primary key (CategoriaCodigo)
    )on  AlmacenEsquemaParticion  (CategoriaCodigo)
end
go



--TABLA PROVEEDOR
if not exists (select * from Information_Schema.Tables WHERE TABLE_SCHEMA = 'Externos' and TABLE_NAME='Proveedor' )
Begin
    create table Externos.Proveedor
    (ProveedorCodigo Codigo ,
     ProveedorNombre Texto,
     ProveedorTelefono nvarchar(10)not null,
     ProveedorCorreo TextoNumerico
     constraint ProveedorCodigoPK primary key (ProveedorCodigo)
     )on  EstablecimientoEsquemaParticion  (ProveedorCodigo)
end
go

--TABLA PEDIDO
if not exists (select * from Information_Schema.Tables WHERE TABLE_SCHEMA = 'Externos' and TABLE_NAME= 'Pedido')
Begin
    create table Externos.Pedido
    (PedidoCodigo Codigo,
    PedidoDescripcion TextoNumerico,
    ValorPedido numeric(9,2) default 0,
    PedidoFechaEmision Date not null,
	PedidoFechaRecepcion Date not null,
	PedidoEstado nchar(10) default 'Pendiente',
    ProveedorCodigo Codigo,
    constraint PedidoCodigoPK primary key (PedidoCodigo),
    constraint ProveedorCodigoFK foreign key (ProveedorCodigo) references Externos.Proveedor(ProveedorCodigo),
    constraint PedidoEstadoCk check (PedidoEstado='Pendiente'or PedidoEstado='En Espera' or PedidoEstado='Recibido')
	)on AlmacenEsquemaParticion (PedidoCodigo)
end
go

--TABLA PERSONA
if not exists (select * from Information_Schema.Tables WHERE TABLE_SCHEMA = 'Administracion' and TABLE_NAME= 'Persona')
Begin
create table Administracion.Persona
(PersonaCodigo Codigo ,
PersonaDNI nchar(8),
PersonaApellidoMaterno Texto,
PersonaApellidoPaterno Texto,
PersonaNombre Texto,
PersonaNombreCompleto As upper(PersonaApellidoPaterno+ space(1)+PersonaApellidoMaterno+space(1)+PersonaNombre),
PersonaEdad nchar(10)not null,
PersonaSexo nchar(1)not null,
PersonaDireccion TextoNumerico,
PersonaTelefono nchar(9) not null,
PersonaCorreo TextoNumerico,
constraint PersonaCodigoPK primary key(PersonaCodigo) ,
constraint PersonaSexoCK check (PersonaSexo='M' or PersonaSexo='F')
)on EstablecimientoEsquemaParticion (PersonaCodigo)
end
go

--TABLA GERENTE
if not exists (select * from Information_Schema.Tables WHERE TABLE_SCHEMA = 'Administracion' and TABLE_NAME='Gerente')
 Begin
  create table Administracion.Gerente
   (GerenteCodigo Codigo,
    GerenteNegocio TextoNumerico,
   GerenteUser nvarchar(60) not null,
   GerentePassword nvarchar(60) not null,
   PersonaCodigo Codigo,
   constraint GerenteCodigoPK primary key (GerenteCodigo),
   constraint PersonaCodigoFK foreign key (PersonaCodigo) references Administracion.Persona(PersonaCodigo)
   )on EstablecimientoEsquemaParticion (GerenteCodigo)
  end
go
 
--TABLA EMPLEADO
 if not exists (select * from Information_Schema.Tables WHERE TABLE_SCHEMA = 'Administracion' and TABLE_NAME='Empleado')
 Begin
  create table Administracion.Empleado
   (EmpleadoCodigo Codigo,
   EmpleadoCargo varchar(100)not null,
   EmpleadoUser nvarchar(60) not null,
   EmpleadoPassword nvarchar(60) not null,
   CodigoPersona Codigo,
   constraint EmpleadoCodigoPK primary key (EmpleadoCodigo),
   constraint CodigoPersona foreign key (CodigoPersona) references Administracion.Persona(PersonaCodigo)
   )on EstablecimientoEsquemaParticion (EmpleadoCodigo)
  end
go

--TABLA PRODUCTO
if not exists (select * from Information_Schema.Tables WHERE TABLE_SCHEMA = 'Almacen' and TABLE_NAME= 'Producto')
Begin
     create table Almacen.Producto
     (ProductoCodigo Codigo ,
     ProductoNombre nvarchar(100) not null,
     ProductoDescripcion TextoNumerico,
     ProductoPrecioCompra numeric(9,2) not null default 0,
     ProductoPrecioVenta numeric(9,2) not null default 0,
	 ProductoUnidadesVendidas nchar(10) not null default 0,
	 ProductoMarca nvarchar(100) not null,
     ProductoStock nchar(10) not null default 0,
	 FechaDeRegistro Date not null,
     CategoriaCodigo Codigo,
	 PedidoCodigo Codigo,
	 GerenteCodigo Codigo,
     constraint ProductoCodigoPK primary key (ProductoCodigo),
     constraint CategoriaCodigoFK foreign key (CategoriaCodigo) references Almacen.Categoria(CategoriaCodigo) on delete cascade,
	 constraint PedidoCodigoFK foreign key (PedidoCodigo) references Externos.Pedido(PedidoCodigo),
	 constraint GerenteCodigo foreign key (GerenteCodigo) references Administracion.Gerente(GerenteCodigo)
    ) on AlmacenEsquemaParticion (ProductoCodigo)
end
go


--------CREACION DE INDICES-------
if not exists (select * from sys.indexes where name = 'ProductoNombreDescripcionIDXa')
Begin
create index ProductoNombreDescripcionIDXa
    on Almacen.Producto(ProductoNombre,ProductoDescripcion)
end
go

if not exists (select * from sys.indexes where name = 'EmpleadoPasswordIDXa')
Begin
create index EmpleadoPasswordIDXa
    on Administracion.Empleado(EmpleadoUser,EmpleadoPassword)
end
go

--------FUNCIONES DEFINIDAS POR EL USUARIO--------------------

--FDU VALOR DE STOCK POR CATEGORIA (A TRAVES DEL PRECIO DE VENTA)
Create function Almacen.FDUValorStockPorCategoria(@CodigoCategoria nchar)
Returns Numeric(9,2) 
As
Begin

Declare @ValorStockTotal Numeric(9,2)
set @ValorStockTotal = (select SUM(P.ProductoPrecioVenta * P.ProductoStock)
from Almacen.Producto as P where CategoriaCodigo = @CodigoCategoria )
Return @ValorStockTotal
End
go
--FDU VALOR STOCK POR PRODUCTO (A TRAVES DEL PRECIO DE COMPRA)
create function Almacen.FDUValorStockPorProducto(@CodigoProducto nchar)
Returns Numeric(9,2) 
As
Begin

Declare @ValorStockProducto Numeric(9,2)
set @ValorStockProducto = (select SUM(P.ProductoPrecioCompra * P.ProductoStock)
from Almacen.Producto as P where ProductoCodigo = @CodigoProducto )
Return @ValorStockProducto
End
go


--------PROCEDIMIENTOS ALMACENADOS DE CATEGORIA-------

--AGREGAR CATEGORIA
if exists (select * from sys.procedures where name='Almacen.spAgregarCategoria' )
begin
	  DROP procedure Almacen.spAgregarCategoria
	end	
go

if not exists (select * from sys.procedures where name='Almacen.spAgregarCategoria' )
begin
		exec('create procedure Almacen.spAgregarCategoria
@CodigoCategoria nchar(8),
@NombreCategoria varchar(100),
@DescripcionCategoria varchar(200)
as 
 insert into Almacen.Categoria values (@CodigoCategoria,@NombreCategoria,@DescripcionCategoria)')
	end	
go

--EDITAR CATEGORIA
if exists (select * from sys.procedures where name='spEditarCategoria' )
    begin
		drop procedure Almacen.spEditarCategoria
	end	
go

if not exists (select * from sys.procedures where name='spEditarCategoria' )
begin
  exec('create procedure Almacen.spEditarCategoria
      @CodigoCategoria nchar(8),
      @NombreCategoria varchar(100),
      @DescripcionCategoria varchar(200)
      as 
      update Almacen.Categoria set  CategoriaNombre= @NombreCategoria,
      CategoriaDescripcion= @DescripcionCategoria where CategoriaCodigo= @CodigoCategoria')
	end	
go

--LISTAR CATEGORIA

if exists (select * from sys.procedures where name='Almacen.spListaCategoria' )
begin
    drop procedure Almacen.spListaCategoria
   end
else  
    begin 
	   exec('create procedure Almacen.spListaCategoria
          as
          select CategoriaCodigo as "Codigo",CategoriaNombre as "Nombre" ,CategoriaDescripcion as "Descripción" from Almacen.Categoria')
	end
go


--TOTAL CATEGORIAS
if  exists (select * from sys.procedures where name='Almacen.spTotalCategorias' )
   begin
     drop procedure Almacen.spTotalCategorias
	 end
else 
  begin
     exec ('create procedure Almacen.spTotalCategorias 
           as
	       select COUNT(*) as "Total Categorias" from Almacen.Categoria')
  end
go

--ELIMINAR CATEGORIA

if exists (select * from sys.procedures where name='spEliminarCategoria' )
    begin 
      drop procedure Almacen.spEliminarCategoria
	end
else
   begin
    exec('create procedure Almacen.spEliminarCategoria 
        @CodigoCategoria nchar(8)   
	    as
	     delete from Almacen.Categoria where CategoriaCodigo=@CodigoCategoria')
   end
go


--------PROCEDIMIENTOS ALMACENADOS DE PROVEEDORES-------

--REGISTRAR PROVEEDOR

if exists (select * from sys.procedures where name='Externos.spRegistrarProveedor' )
   begin
      drop procedure Externos.spRegistrarProveedor
   end
else
   begin
     exec('create procedure Externos.spRegistrarProveedor
           @CodigoProveedor nchar(8) ,--codigo
           @NombreProveedor varchar(100),--texto
           @TelefonoProveedor nvarchar(10),
           @CorreoProveedor nvarchar(200)--textonumerico
           as 
           Insert into Externos.Proveedor values (@CodigoProveedor,@NombreProveedor,@TelefonoProveedor,@CorreoProveedor)')
end
go


--LISTAR PROVEEDORES

if exists (select * from sys.procedures where name='spListaProveedores' )
    begin
		drop procedure Externos.spListaProveedores
	end
else 
   begin
     exec('create procedure Externos.spListaProveedores
          as
          select ProveedorCodigo as "Codigo", ProveedorNombre as "Empresa", ProveedorCorreo as "Correo", 
          ProveedorTelefono as "Contacto" from Externos.Proveedor')
   end
go


--EDITAR PROVEEDORES
if exists (select * from sys.procedures where name='spEditarProveedor' )
   begin
		drop procedure Externos.spEditarProveedor
	end	 

else
   begin
       exec('create procedure Externos.spEditarProveedor
            @CodigoProveedor nchar(8) ,--codigo
            @NombreProveedor varchar(100),--texto
            @TelefonoProveedor nvarchar(10),
            @CorreoProveedor nvarchar(200)--textonumerico
            as 
            update  Externos.Proveedor set  ProveedorNombre=@NombreProveedor,
		    ProveedorTelefono= @TelefonoProveedor, ProveedorCorreo=@CorreoProveedor 
		    where ProveedorCodigo=@CodigoProveedor')
	end
 go

  

--ELIMINAR PROVEEDOR

if exists (select * from sys.procedures where name='spEliminarProveedor' )
    begin
		drop procedure Externos.spEliminarProveedor
	end	
else
  begin
       exec('create proc Externos.spEliminarProveedor
            @CodigoProveedor nchar(8)
            as
           delete from Externos.Proveedor where ProveedorCodigo=@CodigoProveedor')
  end
go



--CANTIDAD DE PROVEEDORES

if  exists (select * from sys.procedures where name='spCantidadProvedores' )
    begin
		drop procedure Externos.spCantidadProveedores
	end
else
   begin
       exec ('create procedure Externos.spCantidadProveedores 
              as
	         select COUNT(*) as "Cantidad de Proveedores" from Externos.Proveedor')
   end
go


 
--------PROCEDIMIENTOS ALMACENADOS DE PEDIDOS-------

--AGREGAR PEDIDO
if  exists (select * from sys.procedures where name='Externos.spAgregarPedido' )
    begin
		drop procedure Externos.spAgregarPedido
	end 
else
    begin
        exec('create procedure Externos.spAgregarPedido
              @CodigoPedido nchar(8),
              @DescripcionPedido nvarchar(200),
              @PedidoValor numeric(9,2),
              @FechaEmisionPedido Date ,
              @FechaRecepcionPedido Date ,
              @EstadoPedido nchar(10) ,
              @CodigoProveedor nchar(8)
              as 
              insert into Externos.Pedido values (@CodigoPedido,@DescripcionPedido,@PedidoValor,@FechaEmisionPedido ,
              @FechaRecepcionPedido ,@EstadoPedido,@CodigoProveedor)')
   end
go
      
--EDITAR PEDIDO

if exists (select * from sys.procedures where name='Externos.spEditarPedido' )
   begin
		drop procedure Externos.spEditarPedido
	end

else
   begin
       exec('create procedure Externos.spEditarPedido
             @CodigoPedido nchar(8),
             @DescripcionPedido nvarchar(200),
             @PedidoValor numeric(9,2),
             @FechaEmisionPedido Date ,
             @FechaRecepcionPedido Date ,
             @EstadoPedido nchar(10) ,
             @CodigoProveedor nchar(8)
             as 
             update Externos.Pedido set  PedidoDescripcion= @DescripcionPedido,ValorPedido = @PedidoValor,
             PedidoFechaEmision= @FechaEmisionPedido , PedidoFechaRecepcion = @FechaRecepcionPedido , PedidoEstado= @EstadoPedido,
             ProveedorCodigo= @CodigoProveedor where PedidoCodigo= @CodigoPedido')
   end
go
  
 -- exec Externos.spEditarPedido 4,'Pedido de nito ',25.0,'2018-07-15','2018-07-20','Pendiente',3

--ELIMINAR PEDIDO

if exists (select * from sys.procedures where name='Externos.spEliminarPedido' )
   begin
		drop procedure Externos.spEliminarPedido
	end	 
else
   begin
        exec('create proc Externos.spEliminarPedido
              @CodigoPedido nchar(8)
              as
              delete from Externos.Pedido where PedidoCodigo=@CodigoPedido')
   end
go

--CANTIDAD PEDIDO

if exists (select * from sys.procedures where name='Externos.spCantidadPedido' )
   begin
		drop procedure Externos.spCantidadPedido
	end
else
   begin
        exec('create procedure Externos.spCantidadPedido
              as
	         select COUNT(*) as "Total de Pedidos" from Externos.Pedido')
   end
go

--LISTAR PEDIDOS

if exists (select * from sys.procedures where name='Externos.spListaPedido' )
   begin
		drop procedure Externos.spListaPedido
	end	
else
   begin
       exec('create procedure Externos.spListaPedido
             as 
             select   P.PedidoCodigo as "Codigo"  ,Pro.ProveedorNombre as "Proveedor" ,
			 P.PedidoDescripcion as "Descripción", P.PedidoFechaEmision as "Dia Solicitado", P.PedidoFechaRecepcion as
             "Dia de Entrega" , Pro.ProveedorTelefono as "Contacto", P.PedidoEstado as "Estado",P.ValorPedido as "Costo del Pedido"  
			 from Externos.Pedido  as P inner join Externos.Proveedor as Pro 
             on P.ProveedorCodigo= Pro.ProveedorCodigo')
   end
go



--------PROCEDIMIENTOS ALMACENADOS PARA PERSONA-------
--AGREGAR PERSONA

if exists (select * from sys.procedures where name='Administracion.spAgregarPersona' )
   begin
		drop procedure Administracion.spAgregarPersona
	end
else
   begin  
        exec ('create  procedure Administracion.spAgregarPersona
               @CodigoPersona nchar(8),
               @DNIPersona nchar(8),
               @ApellidoMaternoPersona varchar(100),
               @ApellidoPaternoPersona varchar(100),
               @NombrePersona varchar(100),
               @EdadPersona nchar(10),
               @SexoPersona nchar(1),
               @DireccionPersona nvarchar(200),
               @TelefonoPersona nchar(9) ,
              @CorreoPersona nvarchar(200)
              as 
              insert into Administracion.Persona values (@CodigoPersona,@DNIPersona,@ApellidoMaternoPersona,
	          @ApellidoPaternoPersona,@NombrePersona,@EdadPersona,@SexoPersona,@DireccionPersona,@TelefonoPersona,@CorreoPersona)')
   end
go

--exec Administracion.spAgregarPersona 2,17863287,'Castillo','Luna','Francisco',19,'M','AV. El Ejercito 563-A',977812400,'flunac567@gmail.com'

--EDITAR PERSONA

if  exists (select * from sys.procedures where name='Administracion.spEditarPersona' )
    begin
		drop procedure Administracion.spEditarPersona
	end	
else
  begin  
exec ('create  procedure Administracion.spEditarPersona
       @CodigoPersona nchar(8),
       @DNIPersona nchar(8),
       @ApellidoMaternoPersona varchar(100),
       @ApellidoPaternoPersona varchar(100),
       @NombrePersona varchar(100),
       @EdadPersona nchar(10),
       @SexoPersona nchar(1),
       @DireccionPersona nvarchar(200),
       @TelefonoPersona nchar(9) ,
       @CorreoPersona nvarchar(200)
    as 
       update Administracion.Persona set PersonaDNI= @DNIPersona,PersonaApellidoMaterno= @ApellidoMaternoPersona,
	 PersonaApellidoPaterno = @ApellidoPaternoPersona, PersonaNombre= @NombrePersona,PersonaEdad = @EdadPersona,PersonaSexo= @SexoPersona,PersonaDireccion= @DireccionPersona,
	PersonaTelefono= @TelefonoPersona,PersonaCorreo= @CorreoPersona where PersonaCodigo= @CodigoPersona')
   end
go

--ELIMINAR PERSONA

if  exists (select * from sys.procedures where name='Administracion.spEliminarPersona' )
    begin
		drop procedure Administracion.spEliminarPersona
	end	

else
   begin  
exec ('create  procedure Administracion.spEliminarPersona
       @CodigoPersona nchar(8)
    as 
       delete from Administracion.Persona where PersonaCodigo= @CodigoPersona')
   end
go

--MOSTRAR DATOS 

if  exists (select * from sys.procedures where name='Administracion.spListaDatosPersona' )
    begin
		drop procedure Administracion.spListaDatosPersona
	end	
else   
   begin  
      exec ('create  procedure Administracion.spListaDatosPersona
            as 
            select PersonaCodigo as "Codigo",PersonaNombreCompleto  as "Nombre", PersonaDNI as "Nuemro de DNI",
	        PersonaSexo as "Sexo", PersonaEdad as "Edad", PersonaTelefono as "Contacto", PersonaCorreo as "Correo",
		    PersonaDireccion as "Dierección"
	        from Administracion.Persona')
   end
go



--------PROCEDIMIENTOS ALMACENADOS PARA GERENTE-------

--AGREGAR GERENTE

if  exists (select * from sys.procedures where name='Administracion.spRegistrarGerente' )
    begin
		drop procedure Administracion.spRegistrarGerente
	end	
else 
begin
exec ('create procedure Administracion.spRegistrarGerente
 @CodigoGerente nchar(8),
 @NegocioGerente nvarchar(200),
 @UserGerente nvarchar(60) ,
 @PasswordGerente nvarchar(60) ,
 @CodigoPersona nchar(8)
 as
    insert into Administracion.Gerente values (@CodigoGerente,@NegocioGerente,@UserGerente,@PasswordGerente,@CodigoPersona)')
	end
go

---------MODIFICACION DEL PROCEDIMIENTO PARA ENCRYPTACION DE CONTRASEÑA
if exists (select * from sys.procedures where name='Administracion.spRegistrarGerente' )
begin
exec ('alter procedure Administracion.spRegistrarGerente
      @CodigoGerente nchar(8),
      @NegocioGerente nvarchar(200),
      @UserGerente nvarchar(60) ,
      @PasswordGerente nvarchar(60) ,
      @CodigoPersona nchar(8)
    as
     insert into Administracion.Gerente values (@CodigoGerente,@NegocioGerente,
	 @UserGerente,EncryptByPassPhrase("P@sswordAdmin",@PasswordGerente),@CodigoPersona)')
	end
go


--EDITAR GERENTE

if  exists (select * from sys.procedures where name='Administracion.spEditarGerente' )
    begin
		drop procedure Administracion.spEditarGerente
	end	
else
begin
exec('create procedure Administracion.spEditarGerente
 @CodigoGerente nchar(8),
 @NegocioGerente nvarchar(200),
 @UserGerente nvarchar(60) ,
 @PasswordGerente nvarchar(60) ,
 @CodigoPersona nchar(8)
 as
    update  Administracion.Gerente set GerenteNegocio =@NegocioGerente,GerenteUser= @UserGerente,
	GerentePassword= @PasswordGerente,PersonaCodigo=@CodigoPersona where GerenteCodigo= @CodigoGerente')
	end
go

--ELIMINAR GERENTE

if exists (select * from sys.procedures where name='Administracion.spEliminarGerente ' )
   begin
		drop procedure Administracion.spEliminarGerente
	end
else
begin
exec('create procedure Administracion.spEliminarGerente 
      @CodigoGerente nchar(8)
     as
      delete from Administracion.Gerente where GerenteCodigo=@CodigoGerente')
	  end
go

--LOGIN GERENTE

if  exists (select * from sys.procedures where name='Administracion.spLoginGerente ' )
    begin
		drop procedure Administracion.spLoginGerente
	end
else
begin
exec('create procedure Administracion.spLoginGerente
      @UserGerente nvarchar(60) ,
      @PasswordGerente nvarchar(60) 
     as  
  select GerenteUser,GerentePassword from Administracion.Gerente
    where GerenteUser = @UserGerente and GerentePassword = @PasswordGerente')
	end
go


--------PROCEDIMIENTOS ALMACENADOS PARA EMPLEADOS-------

--AGREGAR EMPLEADO

if exists (select * from sys.procedures where name='Administracion.spRegistrarEmpleado' )
   begin
		drop procedure Administracion.spRegistrarEmpleado
	end
else 
begin
exec('create procedure  Administracion.spRegistrarEmpleado
     @CodigoEmpleado nchar(8),
     @CargoEmpleado  varchar(100),
     @UserEmpleado nvarchar(60) ,
     @PasswordEmpleado nvarchar(60) ,
     @PersonaCodigo nchar(8)
    as 
     insert into Administracion.Empleado values (@CodigoEmpleado,@CargoEmpleado,@UserEmpleado,@PasswordEmpleado,@PersonaCodigo)')
	 end
go


---------MODIFICACION DEL PROCEDIMIENTO PARA ENCRYPTACION DE CONTRASEÑA
if exists (select * from sys.procedures where name='Administracion.spRegistrarEmpleado' )
begin
exec('alter procedure  Administracion.spRegistrarEmpleado
     @CodigoEmpleado nchar(8),
     @CargoEmpleado  varchar(100),
     @UserEmpleado nvarchar(60) ,
     @PasswordEmpleado nvarchar(60) ,
     @PersonaCodigo nchar(8)
    as 
     insert into Administracion.Empleado values (@CodigoEmpleado,@CargoEmpleado,@UserEmpleado,
	 EncryptByPassPhrase("P@sswordEmp",@PasswordEmpleado),@PersonaCodigo)')
	 end
go

--EDITAR EMPLEADO


if  exists (select * from sys.procedures where name='Administracion.spEditarEmpleado' )
   begin
		drop procedure Administracion.spEditarEmpleado
	end	
else
begin
exec('create procedure  Administracion.spEditarEmpleado
     @CodigoEmpleado nchar(8),
     @CargoEmpleado  varchar(100),
     @UserEmpleado nvarchar(60) ,
     @PasswordEmpleado nvarchar(60) ,
     @PersonaCodigo nchar(8)
    as 
    update Administracion.Empleado set EmpleadoCargo= @CargoEmpleado,EmpleadoUser= @UserEmpleado,
     EmpleadoPassword= @PasswordEmpleado,CodigoPersona= @PersonaCodigo where EmpleadoCodigo= @CodigoEmpleado')
   end
go

--ELIMINAR EMPLEADO

if exists (select * from sys.procedures where name='Administracion.spELiminarEmpleado' )
   begin
		drop procedure Administracion.spEliminarEmpleado
	end	
else
begin
   exec('create procedure Administracion.spELiminarEmpleado
       @CodigoEmpleado nchar(8)
        as
        delete from Administracion.Empleado where EmpleadoCodigo=@CodigoEmpleado')
		end
go

--CANTIDAD EMPLEADOS

if exists (select * from sys.procedures where name='Administracion.spCantidadEmpleados' )
   begin
		drop procedure Administracion.spCantidadEmpleados
	end	

else
begin
exec('create procedure Administracion.spCantidadEmpleados
     as 
   select COUNT(*) as "Total Empleados" from Administracion.Empleado')
   end
go

--LOGIN EMPLEADO


if  exists (select * from sys.procedures where name=' Administracion.spLoginEmpleado' )
   begin
		drop procedure Administracion.spLoginEmpleado
	end
else
begin
exec ('create procedure Administracion.spLoginEmpleado
        @UserEmpleado nvarchar(60) ,
        @PasswordEmpleado nvarchar(60) 
        as  
      select EmpleadoUser as "Usuario" ,EmpleadoPassword as "Contraseña" from Administracion.Empleado
    where EmpleadoUser = @UserEmpleado and EmpleadoPassword = @PasswordEmpleado')
	end
go

--------PROCEDIMIENTOS ALMACENADOS PARA PRODUCTO-------

--AGREGAR PRODUCTO

if exists (select * from sys.procedures where name='Almacen.spAgregarProducto' )
   begin
	  drop procedure Almacen.spAgregarProducto
	end	
else
begin
exec ('create procedure Almacen.spAgregarProducto
    @CodigoProducto nchar(8) ,
    @NombreProducto nvarchar(100) ,
    @DescripcionProducto nvarchar(200),
    @PrecioCompraProducto numeric(9,2) ,
    @PrecioVentaProducto numeric(9,2) ,
	@UnidadesVendidasProducto nchar(10) ,
	@MarcaProducto nvarchar(100) ,
    @StockProducto nchar(10),
	@RegistroFecha Date,
    @CodigoCategoria nchar(8),
	@CodigoPedido nchar(8),
	@CodigoGerente nchar(8)
  as
     insert into Almacen.Producto values (@CodigoProducto,@NombreProducto,@DescripcionProducto,@PrecioCompraProducto,
	 @PrecioVentaProducto,@UnidadesVendidasProducto,@MarcaProducto,@StockProducto,@RegistroFecha,@CodigoCategoria,
	 @CodigoPedido,@CodigoGerente)')
end
go

--EDITAR PRODUCTO

if exists (select * from sys.procedures where name='Almacen.spEditarProducto' )
   begin
	  drop procedure Almacen.spEditarProducto
	end	
else  
begin
     exec('create procedure Almacen.spEditarProducto
    @CodigoProducto nchar(8) ,
    @NombreProducto nvarchar(100) ,
    @DescripcionProducto nvarchar(200),
    @PrecioCompraProducto numeric(9,2) ,
    @PrecioVentaProducto numeric(9,2) ,
	@UnidadesVendidasProducto nchar(10) ,
	@MarcaProducto nvarchar(100) ,
    @StockProducto nchar(10),
	@RegistroFecha Date,
    @CodigoCategoria nchar(8),
	@CodigoPedido nchar(8),
	@CodigoGerente nchar(8)
  as
     update Almacen.Producto set ProductoNombre=@NombreProducto, ProductoDescripcion=@DescripcionProducto, ProductoPrecioCompra=@PrecioCompraProducto,
	 ProductoPrecioVenta=@PrecioVentaProducto,ProductoUnidadesVendidas=@UnidadesVendidasProducto,ProductoMarca=@MarcaProducto,ProductoStock=@StockProducto,
	 FechaDeRegistro=@RegistroFecha,CategoriaCodigo=@CodigoCategoria,PedidoCodigo=@CodigoPedido,GerenteCodigo=@CodigoGerente 
	 where ProductoCodigo=@CodigoProducto')
end
go

--ELIMINAR PRODUCTO

if  exists (select * from sys.procedures where name='Almacen.spEliminarProducto' )
    begin
	    drop procedure Almacen.spEliminarProducto
	end	
else
begin
    exec('create procedure Almacen.spEliminarProducto
         @CodigoProducto as nchar(8)
      as
        delete from Almacen.Producto where ProductoCodigo=@CodigoProducto')
end
go


--LISTAR PRODUCTOS


if exists (select * from sys.procedures where name='Almacen.spListaProductos' )
   begin
	    drop procedure Almacen.spListaProductos
	end	
else
begin
     exec('create procedure Almacen.spListaProductos
 as 
     select   ProductoMarca as "Marca",ProductoNombre as "Nombre", ProductoDescripcion as "Descripción",
	 ProductoPrecioCompra as "Precio de Compra", ProductoPrecioVenta as "Precio de Venta",
	 ProductoUnidadesVendidas as "Unidades Vendidas",ProductoStock as "Stock", FechaDeRegistro as "Fecha de Registro" 
	 from Almacen.Producto')
end
go




--VALOR DE STOCK POR CATEGORIA

if  exists (select * from sys.procedures where name='Almacen.spValorDeStockPorCategoria' )
    begin
	  drop procedure Almacen.spValorDeStockPorCategoria
	end	
else
begin
    exec('create procedure Almacen.spValorDeStockPorCategoria
          As
        select C.CategoriaCodigo  As "Codigo", C.CategoriaNombre As "Categoría",
        (select COUNT(P.ProductoStock)
         from Almacen.Producto As P where P.CategoriaCodigo = C.CategoriaCodigo)
         As "Stock", Almacen.FDUValorStockPorCategoria(C.CategoriaCodigo) As "Valor Total de Stock"
        from Almacen.Categoria As C
        order by "Stock" desc')
  end
go

--VALOR DE STOCK POR PRODUCTO

if exists (select * from sys.procedures where name='Almacen.spValorDeStockPorProductos' )
   begin
	 drop procedure Almacen.spValorDeStockPorProducto
	end	
else
begin
   exec('create procedure Almacen.spValorDeStockPorProducto
         As
       select P.ProductoCodigo As "Codigo",P.ProductoNombre As "Nombre",P.ProductoDescripcion As "Descripcion",
       P.ProductoStock As "Stock",
       Almacen.FDUValorStockPorProducto(P.ProductoCodigo) As "Valor Total de Stock"
       from Almacen.Producto As P
        order by "Stock" desc')
end
go



-------------------VISTA DE EMPLEADOS------------------------
create view VistaDeEmpleados
as
   select  E.EmpleadoCodigo as "Codigo", E.EmpleadoCargo as "Cargo", P.PersonaNombreCompleto as "Nombre", 
   P.PersonaDNI as "Numero de DNI" , P.PersonaSexo as "Sexo", P.PersonaTelefono as "Teléfono", P.PersonaCorreo as "Correo Electrónico",
   P.PersonaDireccion as "Dirección"
   from Administracion.Empleado as E 
   inner join Administracion.Persona  as P on E.CodigoPersona=P.PersonaCodigo 
go

----------------VISTA DE PROVEEDORES------------------------------
create view VistaListaDeProveedores
as   
   select P.ProveedorCodigo as "Codigo" , P.ProveedorNombre as "Proveedor", P.ProveedorTelefono as "Teléfono",
   P.ProveedorCorreo as "Correo Electrónico"
   from Externos.Proveedor as P
go

----------------VISTA DE PEDIDOS------------------------------

create view VistaListaPedidos
as 
  select PedidoCodigo as "Codigo",PedidoDescripcion as "Descripción", PedidoFechaEmision as "Dia Solicitado", PedidoFechaRecepcion as
  "Dia de Entrega" , PedidoEstado as "Estado",ValorPedido as "Costo del Pedido"  from Externos.Pedido
 go

--------------------VISTAS PARA PRODUCTOS---------------------

--VISTA DE PRODUCTOS
create view VistaProductosCompletos
as 
   select  ProductoCodigo as "Codigo", ProductoMarca as "Marca",ProductoNombre as "Nombre", ProductoDescripcion as "Descripción",
	 ProductoPrecioCompra as "Precio de Compra", ProductoPrecioVenta as "Precio de Venta",
	 ProductoUnidadesVendidas as "Unidades Vendidas",ProductoStock as "Stock", FechaDeRegistro as "Fecha de Registro" ,
	 CategoriaCodigo as "Codigo Categoria", PedidoCodigo as "Codigo de Pedido",GerenteCodigo as "Codigo Gerente"
	 from Almacen.Producto
go

--VISTA VALOR DE STOCK POR PRODUCTO
create view VistaValorDeStockPorProducto
as
 select P.ProductoCodigo As "Codigo",P.ProductoNombre As "Nombre",P.ProductoDescripcion As "Descripcion",
       P.ProductoStock As "Stock",
       Almacen.FDUValorStockPorProducto(P.ProductoCodigo) As "Valor Total de Stock"
       from Almacen.Producto As P      
go

--VISTA VALOR DE STOCK POR CATEGORIA
create view VistaValorDeStockPorCategoria
as 
select C.CategoriaCodigo  As "Codigo", C.CategoriaNombre As "Categoría",
        (select COUNT(P.ProductoStock)
         from Almacen.Producto As P where P.CategoriaCodigo = C.CategoriaCodigo)
         As "Stock", Almacen.FDUValorStockPorCategoria(C.CategoriaCodigo) As "Valor Total de Stock"
        from Almacen.Categoria As C 
go
