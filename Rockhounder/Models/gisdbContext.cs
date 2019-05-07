using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RockHoundr.Models;

namespace RockHoundr.Models
{
    public partial class gisdbContext : DbContext
    {
        public gisdbContext()
        {
        }

        public gisdbContext(DbContextOptions<gisdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Addr> Addr { get; set; }
        public virtual DbSet<Addrfeat> Addrfeat { get; set; }
        public virtual DbSet<Bg> Bg { get; set; }
        public virtual DbSet<County> County { get; set; }
        public virtual DbSet<CountyLookup> CountyLookup { get; set; }
        public virtual DbSet<CountysubLookup> CountysubLookup { get; set; }
        public virtual DbSet<Cousub> Cousub { get; set; }
        public virtual DbSet<DirectionLookup> DirectionLookup { get; set; }
        public virtual DbSet<Edges> Edges { get; set; }
        public virtual DbSet<Faces> Faces { get; set; }
        public virtual DbSet<Featnames> Featnames { get; set; }
        public virtual DbSet<GeocodeSettings> GeocodeSettings { get; set; }
        public virtual DbSet<GeocodeSettingsDefault> GeocodeSettingsDefault { get; set; }
        public virtual DbSet<Landmarks> Landmarks { get; set; }
        public virtual DbSet<Layer> Layer { get; set; }
        public virtual DbSet<LoaderLookuptables> LoaderLookuptables { get; set; }
        public virtual DbSet<LoaderPlatform> LoaderPlatform { get; set; }
        public virtual DbSet<LoaderVariables> LoaderVariables { get; set; }
        public virtual DbSet<PagcGaz> PagcGaz { get; set; }
        public virtual DbSet<PagcLex> PagcLex { get; set; }
        public virtual DbSet<PagcRules> PagcRules { get; set; }
        public virtual DbSet<Place> Place { get; set; }
        public virtual DbSet<PlaceLookup> PlaceLookup { get; set; }
        public virtual DbSet<PointcloudFormats> PointcloudFormats { get; set; }
        public virtual DbSet<SecondaryUnitLookup> SecondaryUnitLookup { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<StateLookup> StateLookup { get; set; }
        public virtual DbSet<StreetTypeLookup> StreetTypeLookup { get; set; }
        public virtual DbSet<Tabblock> Tabblock { get; set; }
        public virtual DbSet<Testrocks> Testrocks { get; set; }
        public virtual DbSet<Topology> Topology { get; set; }
        public virtual DbSet<Tract> Tract { get; set; }
        public virtual DbSet<UsGaz> UsGaz { get; set; }
        public virtual DbSet<UsLex> UsLex { get; set; }
        public virtual DbSet<UsRules> UsRules { get; set; }
        public virtual DbSet<Zcta5> Zcta5 { get; set; }
        public virtual DbSet<ZipLookup> ZipLookup { get; set; }
        public virtual DbSet<ZipLookupBase> ZipLookupBase { get; set; }
        public virtual DbSet<ZipState> ZipState { get; set; }
        public virtual DbSet<ZipStateLoc> ZipStateLoc { get; set; }

        private readonly string connectionString;




        public gisdbContext(string connectionString) : base()
        {
            this.connectionString = connectionString;
        }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseNpgsql(connectionString);

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("address_standardizer")
                .HasPostgresExtension("address_standardizer_data_us")
                .HasPostgresExtension("fuzzystrmatch")
                .HasPostgresExtension("ogr_fdw")
                .HasPostgresExtension("pgrouting")
                .HasPostgresExtension("pointcloud")
                .HasPostgresExtension("pointcloud_postgis")
                .HasPostgresExtension("postgis")
                .HasPostgresExtension("postgis_sfcgal")
                .HasPostgresExtension("postgis_tiger_geocoder")
                .HasPostgresExtension("postgis_topology")
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Addr>(entity =>
            {
                entity.HasKey(e => e.Gid)
                    .HasName("addr_pkey");

                entity.ToTable("addr", "tiger");

                entity.HasIndex(e => e.Zip)
                    .HasName("idx_tiger_addr_zip");

                entity.HasIndex(e => new { e.Tlid, e.Statefp })
                    .HasName("idx_tiger_addr_tlid_statefp");

                entity.Property(e => e.Gid).HasColumnName("gid");

                entity.Property(e => e.Arid)
                    .HasColumnName("arid")
                    .HasMaxLength(22);

                entity.Property(e => e.Fromarmid).HasColumnName("fromarmid");

                entity.Property(e => e.Fromhn)
                    .HasColumnName("fromhn")
                    .HasMaxLength(12);

                entity.Property(e => e.Fromtyp)
                    .HasColumnName("fromtyp")
                    .HasMaxLength(1);

                entity.Property(e => e.Mtfcc)
                    .HasColumnName("mtfcc")
                    .HasMaxLength(5);

                entity.Property(e => e.Plus4)
                    .HasColumnName("plus4")
                    .HasMaxLength(4);

                entity.Property(e => e.Side)
                    .HasColumnName("side")
                    .HasMaxLength(1);

                entity.Property(e => e.Statefp)
                    .HasColumnName("statefp")
                    .HasMaxLength(2);

                entity.Property(e => e.Tlid).HasColumnName("tlid");

                entity.Property(e => e.Toarmid).HasColumnName("toarmid");

                entity.Property(e => e.Tohn)
                    .HasColumnName("tohn")
                    .HasMaxLength(12);

                entity.Property(e => e.Totyp)
                    .HasColumnName("totyp")
                    .HasMaxLength(1);

                entity.Property(e => e.Zip)
                    .HasColumnName("zip")
                    .HasMaxLength(5);
            });

            modelBuilder.Entity<Addrfeat>(entity =>
            {
                entity.HasKey(e => e.Gid)
                    .HasName("addrfeat_pkey");

                entity.ToTable("addrfeat", "tiger");

                entity.HasIndex(e => e.Tlid)
                    .HasName("idx_addrfeat_tlid");

                entity.HasIndex(e => e.Zipl)
                    .HasName("idx_addrfeat_zipl");

                entity.HasIndex(e => e.Zipr)
                    .HasName("idx_addrfeat_zipr");

                entity.Property(e => e.Gid).HasColumnName("gid");

                entity.Property(e => e.Aridl)
                    .HasColumnName("aridl")
                    .HasMaxLength(22);

                entity.Property(e => e.Aridr)
                    .HasColumnName("aridr")
                    .HasMaxLength(22);

                entity.Property(e => e.EdgeMtfcc)
                    .HasColumnName("edge_mtfcc")
                    .HasMaxLength(5);

                entity.Property(e => e.Fullname)
                    .HasColumnName("fullname")
                    .HasMaxLength(100);

                entity.Property(e => e.Lfromhn)
                    .HasColumnName("lfromhn")
                    .HasMaxLength(12);

                entity.Property(e => e.Lfromtyp)
                    .HasColumnName("lfromtyp")
                    .HasMaxLength(1);

                entity.Property(e => e.Linearid)
                    .HasColumnName("linearid")
                    .HasMaxLength(22);

                entity.Property(e => e.Ltohn)
                    .HasColumnName("ltohn")
                    .HasMaxLength(12);

                entity.Property(e => e.Ltotyp)
                    .HasColumnName("ltotyp")
                    .HasMaxLength(1);

                entity.Property(e => e.Offsetl)
                    .HasColumnName("offsetl")
                    .HasMaxLength(1);

                entity.Property(e => e.Offsetr)
                    .HasColumnName("offsetr")
                    .HasMaxLength(1);

                entity.Property(e => e.Parityl)
                    .HasColumnName("parityl")
                    .HasMaxLength(1);

                entity.Property(e => e.Parityr)
                    .HasColumnName("parityr")
                    .HasMaxLength(1);

                entity.Property(e => e.Plus4l)
                    .HasColumnName("plus4l")
                    .HasMaxLength(4);

                entity.Property(e => e.Plus4r)
                    .HasColumnName("plus4r")
                    .HasMaxLength(4);

                entity.Property(e => e.Rfromhn)
                    .HasColumnName("rfromhn")
                    .HasMaxLength(12);

                entity.Property(e => e.Rfromtyp)
                    .HasColumnName("rfromtyp")
                    .HasMaxLength(1);

                entity.Property(e => e.Rtohn)
                    .HasColumnName("rtohn")
                    .HasMaxLength(12);

                entity.Property(e => e.Rtotyp)
                    .HasColumnName("rtotyp")
                    .HasMaxLength(1);

                entity.Property(e => e.Statefp)
                    .IsRequired()
                    .HasColumnName("statefp")
                    .HasMaxLength(2);

                entity.Property(e => e.Tlid).HasColumnName("tlid");

                entity.Property(e => e.Zipl)
                    .HasColumnName("zipl")
                    .HasMaxLength(5);

                entity.Property(e => e.Zipr)
                    .HasColumnName("zipr")
                    .HasMaxLength(5);
            });

            modelBuilder.Entity<Bg>(entity =>
            {
                entity.ToTable("bg", "tiger");

                entity.ForNpgsqlHasComment("block groups");

                entity.Property(e => e.BgId)
                    .HasColumnName("bg_id")
                    .HasMaxLength(12)
                    .ValueGeneratedNever();

                entity.Property(e => e.Aland).HasColumnName("aland");

                entity.Property(e => e.Awater).HasColumnName("awater");

                entity.Property(e => e.Blkgrpce)
                    .HasColumnName("blkgrpce")
                    .HasMaxLength(1);

                entity.Property(e => e.Countyfp)
                    .HasColumnName("countyfp")
                    .HasMaxLength(3);

                entity.Property(e => e.Funcstat)
                    .HasColumnName("funcstat")
                    .HasMaxLength(1);

                entity.Property(e => e.Gid)
                    .HasColumnName("gid")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Intptlat)
                    .HasColumnName("intptlat")
                    .HasMaxLength(11);

                entity.Property(e => e.Intptlon)
                    .HasColumnName("intptlon")
                    .HasMaxLength(12);

                entity.Property(e => e.Mtfcc)
                    .HasColumnName("mtfcc")
                    .HasMaxLength(5);

                entity.Property(e => e.Namelsad)
                    .HasColumnName("namelsad")
                    .HasMaxLength(13);

                entity.Property(e => e.Statefp)
                    .HasColumnName("statefp")
                    .HasMaxLength(2);

                entity.Property(e => e.Tractce)
                    .HasColumnName("tractce")
                    .HasMaxLength(6);
            });

            modelBuilder.Entity<County>(entity =>
            {
                entity.HasKey(e => e.Cntyidfp)
                    .HasName("pk_tiger_county");

                entity.ToTable("county", "tiger");

                entity.HasIndex(e => e.Countyfp)
                    .HasName("idx_tiger_county");

                entity.HasIndex(e => e.Gid)
                    .HasName("uidx_county_gid")
                    .IsUnique();

                entity.Property(e => e.Cntyidfp)
                    .HasColumnName("cntyidfp")
                    .HasMaxLength(5)
                    .ValueGeneratedNever();

                entity.Property(e => e.Aland).HasColumnName("aland");

                entity.Property(e => e.Awater).HasColumnName("awater");

                entity.Property(e => e.Cbsafp)
                    .HasColumnName("cbsafp")
                    .HasMaxLength(5);

                entity.Property(e => e.Classfp)
                    .HasColumnName("classfp")
                    .HasMaxLength(2);

                entity.Property(e => e.Countyfp)
                    .HasColumnName("countyfp")
                    .HasMaxLength(3);

                entity.Property(e => e.Countyns)
                    .HasColumnName("countyns")
                    .HasMaxLength(8);

                entity.Property(e => e.Csafp)
                    .HasColumnName("csafp")
                    .HasMaxLength(3);

                entity.Property(e => e.Funcstat)
                    .HasColumnName("funcstat")
                    .HasMaxLength(1);

                entity.Property(e => e.Gid)
                    .HasColumnName("gid")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Intptlat)
                    .HasColumnName("intptlat")
                    .HasMaxLength(11);

                entity.Property(e => e.Intptlon)
                    .HasColumnName("intptlon")
                    .HasMaxLength(12);

                entity.Property(e => e.Lsad)
                    .HasColumnName("lsad")
                    .HasMaxLength(2);

                entity.Property(e => e.Metdivfp)
                    .HasColumnName("metdivfp")
                    .HasMaxLength(5);

                entity.Property(e => e.Mtfcc)
                    .HasColumnName("mtfcc")
                    .HasMaxLength(5);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100);

                entity.Property(e => e.Namelsad)
                    .HasColumnName("namelsad")
                    .HasMaxLength(100);

                entity.Property(e => e.Statefp)
                    .HasColumnName("statefp")
                    .HasMaxLength(2);
            });

            modelBuilder.Entity<CountyLookup>(entity =>
            {
                entity.HasKey(e => new { e.StCode, e.CoCode })
                    .HasName("county_lookup_pkey");

                entity.ToTable("county_lookup", "tiger");

                entity.HasIndex(e => e.State)
                    .HasName("county_lookup_state_idx");

                entity.Property(e => e.StCode).HasColumnName("st_code");

                entity.Property(e => e.CoCode).HasColumnName("co_code");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(90);

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasMaxLength(2);
            });

            modelBuilder.Entity<CountysubLookup>(entity =>
            {
                entity.HasKey(e => new { e.StCode, e.CoCode, e.CsCode })
                    .HasName("countysub_lookup_pkey");

                entity.ToTable("countysub_lookup", "tiger");

                entity.HasIndex(e => e.State)
                    .HasName("countysub_lookup_state_idx");

                entity.Property(e => e.StCode).HasColumnName("st_code");

                entity.Property(e => e.CoCode).HasColumnName("co_code");

                entity.Property(e => e.CsCode).HasColumnName("cs_code");

                entity.Property(e => e.County)
                    .HasColumnName("county")
                    .HasMaxLength(90);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(90);

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasMaxLength(2);
            });

            modelBuilder.Entity<Cousub>(entity =>
            {
                entity.HasKey(e => e.Cosbidfp)
                    .HasName("cousub_pkey");

                entity.ToTable("cousub", "tiger");

                entity.HasIndex(e => e.Gid)
                    .HasName("uidx_cousub_gid")
                    .IsUnique();

                entity.Property(e => e.Cosbidfp)
                    .HasColumnName("cosbidfp")
                    .HasMaxLength(10)
                    .ValueGeneratedNever();

                entity.Property(e => e.Aland)
                    .HasColumnName("aland")
                    .HasColumnType("numeric(14,0)");

                entity.Property(e => e.Awater)
                    .HasColumnName("awater")
                    .HasColumnType("numeric(14,0)");

                entity.Property(e => e.Classfp)
                    .HasColumnName("classfp")
                    .HasMaxLength(2);

                entity.Property(e => e.Cnectafp)
                    .HasColumnName("cnectafp")
                    .HasMaxLength(3);

                entity.Property(e => e.Countyfp)
                    .HasColumnName("countyfp")
                    .HasMaxLength(3);

                entity.Property(e => e.Cousubfp)
                    .HasColumnName("cousubfp")
                    .HasMaxLength(5);

                entity.Property(e => e.Cousubns)
                    .HasColumnName("cousubns")
                    .HasMaxLength(8);

                entity.Property(e => e.Funcstat)
                    .HasColumnName("funcstat")
                    .HasMaxLength(1);

                entity.Property(e => e.Gid)
                    .HasColumnName("gid")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Intptlat)
                    .HasColumnName("intptlat")
                    .HasMaxLength(11);

                entity.Property(e => e.Intptlon)
                    .HasColumnName("intptlon")
                    .HasMaxLength(12);

                entity.Property(e => e.Lsad)
                    .HasColumnName("lsad")
                    .HasMaxLength(2);

                entity.Property(e => e.Mtfcc)
                    .HasColumnName("mtfcc")
                    .HasMaxLength(5);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100);

                entity.Property(e => e.Namelsad)
                    .HasColumnName("namelsad")
                    .HasMaxLength(100);

                entity.Property(e => e.Nctadvfp)
                    .HasColumnName("nctadvfp")
                    .HasMaxLength(5);

                entity.Property(e => e.Nectafp)
                    .HasColumnName("nectafp")
                    .HasMaxLength(5);

                entity.Property(e => e.Statefp)
                    .HasColumnName("statefp")
                    .HasMaxLength(2);
            });

            modelBuilder.Entity<DirectionLookup>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("direction_lookup_pkey");

                entity.ToTable("direction_lookup", "tiger");

                entity.HasIndex(e => e.Abbrev)
                    .HasName("direction_lookup_abbrev_idx");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(20)
                    .ValueGeneratedNever();

                entity.Property(e => e.Abbrev)
                    .HasColumnName("abbrev")
                    .HasMaxLength(3);
            });

            modelBuilder.Entity<Edges>(entity =>
            {
                entity.HasKey(e => e.Gid)
                    .HasName("edges_pkey");

                entity.ToTable("edges", "tiger");

                entity.HasIndex(e => e.Countyfp)
                    .HasName("idx_tiger_edges_countyfp");

                entity.HasIndex(e => e.Tlid)
                    .HasName("idx_edges_tlid");

                entity.Property(e => e.Gid).HasColumnName("gid");

                entity.Property(e => e.Artpath)
                    .HasColumnName("artpath")
                    .HasMaxLength(1);

                entity.Property(e => e.Countyfp)
                    .HasColumnName("countyfp")
                    .HasMaxLength(3);

                entity.Property(e => e.Deckedroad)
                    .HasColumnName("deckedroad")
                    .HasMaxLength(1);

                entity.Property(e => e.Divroad)
                    .HasColumnName("divroad")
                    .HasMaxLength(1);

                entity.Property(e => e.Exttyp)
                    .HasColumnName("exttyp")
                    .HasMaxLength(1);

                entity.Property(e => e.Featcat)
                    .HasColumnName("featcat")
                    .HasMaxLength(1);

                entity.Property(e => e.Fullname)
                    .HasColumnName("fullname")
                    .HasMaxLength(100);

                entity.Property(e => e.Gcseflg)
                    .HasColumnName("gcseflg")
                    .HasMaxLength(1);

                entity.Property(e => e.Hydroflg)
                    .HasColumnName("hydroflg")
                    .HasMaxLength(1);

                entity.Property(e => e.Lfromadd)
                    .HasColumnName("lfromadd")
                    .HasMaxLength(12);

                entity.Property(e => e.Ltoadd)
                    .HasColumnName("ltoadd")
                    .HasMaxLength(12);

                entity.Property(e => e.Mtfcc)
                    .HasColumnName("mtfcc")
                    .HasMaxLength(5);

                entity.Property(e => e.Offsetl)
                    .HasColumnName("offsetl")
                    .HasMaxLength(1);

                entity.Property(e => e.Offsetr)
                    .HasColumnName("offsetr")
                    .HasMaxLength(1);

                entity.Property(e => e.Olfflg)
                    .HasColumnName("olfflg")
                    .HasMaxLength(1);

                entity.Property(e => e.Passflg)
                    .HasColumnName("passflg")
                    .HasMaxLength(1);

                entity.Property(e => e.Persist)
                    .HasColumnName("persist")
                    .HasMaxLength(1);

                entity.Property(e => e.Railflg)
                    .HasColumnName("railflg")
                    .HasMaxLength(1);

                entity.Property(e => e.Rfromadd)
                    .HasColumnName("rfromadd")
                    .HasMaxLength(12);

                entity.Property(e => e.Roadflg)
                    .HasColumnName("roadflg")
                    .HasMaxLength(1);

                entity.Property(e => e.Rtoadd)
                    .HasColumnName("rtoadd")
                    .HasMaxLength(12);

                entity.Property(e => e.Smid)
                    .HasColumnName("smid")
                    .HasMaxLength(22);

                entity.Property(e => e.Statefp)
                    .HasColumnName("statefp")
                    .HasMaxLength(2);

                entity.Property(e => e.Tfidl)
                    .HasColumnName("tfidl")
                    .HasColumnType("numeric(10,0)");

                entity.Property(e => e.Tfidr)
                    .HasColumnName("tfidr")
                    .HasColumnType("numeric(10,0)");

                entity.Property(e => e.Tlid).HasColumnName("tlid");

                entity.Property(e => e.Tnidf)
                    .HasColumnName("tnidf")
                    .HasColumnType("numeric(10,0)");

                entity.Property(e => e.Tnidt)
                    .HasColumnName("tnidt")
                    .HasColumnType("numeric(10,0)");

                entity.Property(e => e.Ttyp)
                    .HasColumnName("ttyp")
                    .HasMaxLength(1);

                entity.Property(e => e.Zipl)
                    .HasColumnName("zipl")
                    .HasMaxLength(5);

                entity.Property(e => e.Zipr)
                    .HasColumnName("zipr")
                    .HasMaxLength(5);
            });

            modelBuilder.Entity<Faces>(entity =>
            {
                entity.HasKey(e => e.Gid)
                    .HasName("faces_pkey");

                entity.ToTable("faces", "tiger");

                entity.HasIndex(e => e.Countyfp)
                    .HasName("idx_tiger_faces_countyfp");

                entity.HasIndex(e => e.Tfid)
                    .HasName("idx_tiger_faces_tfid");

                entity.Property(e => e.Gid).HasColumnName("gid");

                entity.Property(e => e.Aiannhce)
                    .HasColumnName("aiannhce")
                    .HasMaxLength(4);

                entity.Property(e => e.Aiannhce00)
                    .HasColumnName("aiannhce00")
                    .HasMaxLength(4);

                entity.Property(e => e.Aiannhfp)
                    .HasColumnName("aiannhfp")
                    .HasMaxLength(5);

                entity.Property(e => e.Aiannhfp00)
                    .HasColumnName("aiannhfp00")
                    .HasMaxLength(5);

                entity.Property(e => e.Anrcfp)
                    .HasColumnName("anrcfp")
                    .HasMaxLength(5);

                entity.Property(e => e.Anrcfp00)
                    .HasColumnName("anrcfp00")
                    .HasMaxLength(5);

                entity.Property(e => e.Atotal).HasColumnName("atotal");

                entity.Property(e => e.Blkgrpce)
                    .HasColumnName("blkgrpce")
                    .HasMaxLength(1);

                entity.Property(e => e.Blkgrpce00)
                    .HasColumnName("blkgrpce00")
                    .HasMaxLength(1);

                entity.Property(e => e.Blockce)
                    .HasColumnName("blockce")
                    .HasMaxLength(4);

                entity.Property(e => e.Blockce00)
                    .HasColumnName("blockce00")
                    .HasMaxLength(4);

                entity.Property(e => e.Cbsafp)
                    .HasColumnName("cbsafp")
                    .HasMaxLength(5);

                entity.Property(e => e.Cd108fp)
                    .HasColumnName("cd108fp")
                    .HasMaxLength(2);

                entity.Property(e => e.Cd111fp)
                    .HasColumnName("cd111fp")
                    .HasMaxLength(2);

                entity.Property(e => e.Cnectafp)
                    .HasColumnName("cnectafp")
                    .HasMaxLength(3);

                entity.Property(e => e.Comptyp)
                    .HasColumnName("comptyp")
                    .HasMaxLength(1);

                entity.Property(e => e.Comptyp00)
                    .HasColumnName("comptyp00")
                    .HasMaxLength(1);

                entity.Property(e => e.Conctyfp)
                    .HasColumnName("conctyfp")
                    .HasMaxLength(5);

                entity.Property(e => e.Conctyfp00)
                    .HasColumnName("conctyfp00")
                    .HasMaxLength(5);

                entity.Property(e => e.Countyfp)
                    .HasColumnName("countyfp")
                    .HasMaxLength(3);

                entity.Property(e => e.Countyfp00)
                    .HasColumnName("countyfp00")
                    .HasMaxLength(3);

                entity.Property(e => e.Cousubfp)
                    .HasColumnName("cousubfp")
                    .HasMaxLength(5);

                entity.Property(e => e.Cousubfp00)
                    .HasColumnName("cousubfp00")
                    .HasMaxLength(5);

                entity.Property(e => e.Csafp)
                    .HasColumnName("csafp")
                    .HasMaxLength(3);

                entity.Property(e => e.Elsdlea)
                    .HasColumnName("elsdlea")
                    .HasMaxLength(5);

                entity.Property(e => e.Elsdlea00)
                    .HasColumnName("elsdlea00")
                    .HasMaxLength(5);

                entity.Property(e => e.Intptlat)
                    .HasColumnName("intptlat")
                    .HasMaxLength(11);

                entity.Property(e => e.Intptlon)
                    .HasColumnName("intptlon")
                    .HasMaxLength(12);

                entity.Property(e => e.Lwflag)
                    .HasColumnName("lwflag")
                    .HasMaxLength(1);

                entity.Property(e => e.Metdivfp)
                    .HasColumnName("metdivfp")
                    .HasMaxLength(5);

                entity.Property(e => e.Nctadvfp)
                    .HasColumnName("nctadvfp")
                    .HasMaxLength(5);

                entity.Property(e => e.Nectafp)
                    .HasColumnName("nectafp")
                    .HasMaxLength(5);

                entity.Property(e => e.Offset)
                    .HasColumnName("offset")
                    .HasMaxLength(1);

                entity.Property(e => e.Placefp)
                    .HasColumnName("placefp")
                    .HasMaxLength(5);

                entity.Property(e => e.Placefp00)
                    .HasColumnName("placefp00")
                    .HasMaxLength(5);

                entity.Property(e => e.Puma5ce)
                    .HasColumnName("puma5ce")
                    .HasMaxLength(5);

                entity.Property(e => e.Puma5ce00)
                    .HasColumnName("puma5ce00")
                    .HasMaxLength(5);

                entity.Property(e => e.Scsdlea)
                    .HasColumnName("scsdlea")
                    .HasMaxLength(5);

                entity.Property(e => e.Scsdlea00)
                    .HasColumnName("scsdlea00")
                    .HasMaxLength(5);

                entity.Property(e => e.Sldlst)
                    .HasColumnName("sldlst")
                    .HasMaxLength(3);

                entity.Property(e => e.Sldlst00)
                    .HasColumnName("sldlst00")
                    .HasMaxLength(3);

                entity.Property(e => e.Sldust)
                    .HasColumnName("sldust")
                    .HasMaxLength(3);

                entity.Property(e => e.Sldust00)
                    .HasColumnName("sldust00")
                    .HasMaxLength(3);

                entity.Property(e => e.Statefp)
                    .HasColumnName("statefp")
                    .HasMaxLength(2);

                entity.Property(e => e.Statefp00)
                    .HasColumnName("statefp00")
                    .HasMaxLength(2);

                entity.Property(e => e.Submcdfp)
                    .HasColumnName("submcdfp")
                    .HasMaxLength(5);

                entity.Property(e => e.Submcdfp00)
                    .HasColumnName("submcdfp00")
                    .HasMaxLength(5);

                entity.Property(e => e.Tazce)
                    .HasColumnName("tazce")
                    .HasMaxLength(6);

                entity.Property(e => e.Tazce00)
                    .HasColumnName("tazce00")
                    .HasMaxLength(6);

                entity.Property(e => e.Tblkgpce)
                    .HasColumnName("tblkgpce")
                    .HasMaxLength(1);

                entity.Property(e => e.Tfid)
                    .HasColumnName("tfid")
                    .HasColumnType("numeric(10,0)");

                entity.Property(e => e.Tractce)
                    .HasColumnName("tractce")
                    .HasMaxLength(6);

                entity.Property(e => e.Tractce00)
                    .HasColumnName("tractce00")
                    .HasMaxLength(6);

                entity.Property(e => e.Trsubce)
                    .HasColumnName("trsubce")
                    .HasMaxLength(3);

                entity.Property(e => e.Trsubce00)
                    .HasColumnName("trsubce00")
                    .HasMaxLength(3);

                entity.Property(e => e.Trsubfp)
                    .HasColumnName("trsubfp")
                    .HasMaxLength(5);

                entity.Property(e => e.Trsubfp00)
                    .HasColumnName("trsubfp00")
                    .HasMaxLength(5);

                entity.Property(e => e.Ttractce)
                    .HasColumnName("ttractce")
                    .HasMaxLength(6);

                entity.Property(e => e.Uace)
                    .HasColumnName("uace")
                    .HasMaxLength(5);

                entity.Property(e => e.Uace00)
                    .HasColumnName("uace00")
                    .HasMaxLength(5);

                entity.Property(e => e.Ugace)
                    .HasColumnName("ugace")
                    .HasMaxLength(5);

                entity.Property(e => e.Ugace00)
                    .HasColumnName("ugace00")
                    .HasMaxLength(5);

                entity.Property(e => e.Unsdlea)
                    .HasColumnName("unsdlea")
                    .HasMaxLength(5);

                entity.Property(e => e.Unsdlea00)
                    .HasColumnName("unsdlea00")
                    .HasMaxLength(5);

                entity.Property(e => e.Vtdst)
                    .HasColumnName("vtdst")
                    .HasMaxLength(6);

                entity.Property(e => e.Vtdst00)
                    .HasColumnName("vtdst00")
                    .HasMaxLength(6);

                entity.Property(e => e.Zcta5ce)
                    .HasColumnName("zcta5ce")
                    .HasMaxLength(5);

                entity.Property(e => e.Zcta5ce00)
                    .HasColumnName("zcta5ce00")
                    .HasMaxLength(5);
            });

            modelBuilder.Entity<Featnames>(entity =>
            {
                entity.HasKey(e => e.Gid)
                    .HasName("featnames_pkey");

                entity.ToTable("featnames", "tiger");

                entity.HasIndex(e => new { e.Tlid, e.Statefp })
                    .HasName("idx_tiger_featnames_tlid_statefp");

                entity.Property(e => e.Gid).HasColumnName("gid");

                entity.Property(e => e.Fullname)
                    .HasColumnName("fullname")
                    .HasMaxLength(100);

                entity.Property(e => e.Linearid)
                    .HasColumnName("linearid")
                    .HasMaxLength(22);

                entity.Property(e => e.Mtfcc)
                    .HasColumnName("mtfcc")
                    .HasMaxLength(5);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100);

                entity.Property(e => e.Paflag)
                    .HasColumnName("paflag")
                    .HasMaxLength(1);

                entity.Property(e => e.Predir)
                    .HasColumnName("predir")
                    .HasMaxLength(2);

                entity.Property(e => e.Predirabrv)
                    .HasColumnName("predirabrv")
                    .HasMaxLength(15);

                entity.Property(e => e.Prequal)
                    .HasColumnName("prequal")
                    .HasMaxLength(2);

                entity.Property(e => e.Prequalabr)
                    .HasColumnName("prequalabr")
                    .HasMaxLength(15);

                entity.Property(e => e.Pretyp)
                    .HasColumnName("pretyp")
                    .HasMaxLength(3);

                entity.Property(e => e.Pretypabrv)
                    .HasColumnName("pretypabrv")
                    .HasMaxLength(50);

                entity.Property(e => e.Statefp)
                    .HasColumnName("statefp")
                    .HasMaxLength(2);

                entity.Property(e => e.Sufdir)
                    .HasColumnName("sufdir")
                    .HasMaxLength(2);

                entity.Property(e => e.Sufdirabrv)
                    .HasColumnName("sufdirabrv")
                    .HasMaxLength(15);

                entity.Property(e => e.Sufqual)
                    .HasColumnName("sufqual")
                    .HasMaxLength(2);

                entity.Property(e => e.Sufqualabr)
                    .HasColumnName("sufqualabr")
                    .HasMaxLength(15);

                entity.Property(e => e.Suftyp)
                    .HasColumnName("suftyp")
                    .HasMaxLength(3);

                entity.Property(e => e.Suftypabrv)
                    .HasColumnName("suftypabrv")
                    .HasMaxLength(50);

                entity.Property(e => e.Tlid).HasColumnName("tlid");
            });

            modelBuilder.Entity<GeocodeSettings>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("geocode_settings_pkey");

                entity.ToTable("geocode_settings", "tiger");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .ValueGeneratedNever();

                entity.Property(e => e.Category).HasColumnName("category");

                entity.Property(e => e.Setting).HasColumnName("setting");

                entity.Property(e => e.ShortDesc).HasColumnName("short_desc");

                entity.Property(e => e.Unit).HasColumnName("unit");
            });

            modelBuilder.Entity<GeocodeSettingsDefault>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("geocode_settings_default_pkey");

                entity.ToTable("geocode_settings_default", "tiger");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .ValueGeneratedNever();

                entity.Property(e => e.Category).HasColumnName("category");

                entity.Property(e => e.Setting).HasColumnName("setting");

                entity.Property(e => e.ShortDesc).HasColumnName("short_desc");

                entity.Property(e => e.Unit).HasColumnName("unit");
            });

            modelBuilder.Entity<Landmarks>(entity =>
            {
                entity.HasKey(e => e.Gid)
                    .HasName("landmarks_pkey");

                entity.ToTable("landmarks");

                entity.Property(e => e.Gid).HasColumnName("gid");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(50);

                entity.Property(e => e.Architect)
                    .HasColumnName("architect")
                    .HasMaxLength(50);

                entity.Property(e => e.DateBuilt)
                    .HasColumnName("date_built")
                    .HasMaxLength(10);

                entity.Property(e => e.Landmark)
                    .HasColumnName("landmark")
                    .HasMaxLength(10);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Layer>(entity =>
            {
                entity.HasKey(e => new { e.TopologyId, e.LayerId })
                    .HasName("layer_pkey");

                entity.ToTable("layer", "topology");

                entity.HasIndex(e => new { e.SchemaName, e.TableName, e.FeatureColumn })
                    .HasName("layer_schema_name_table_name_feature_column_key")
                    .IsUnique();

                entity.Property(e => e.TopologyId).HasColumnName("topology_id");

                entity.Property(e => e.LayerId).HasColumnName("layer_id");

                entity.Property(e => e.ChildId).HasColumnName("child_id");

                entity.Property(e => e.FeatureColumn)
                    .IsRequired()
                    .HasColumnName("feature_column")
                    .HasColumnType("character varying");

                entity.Property(e => e.FeatureType).HasColumnName("feature_type");

                entity.Property(e => e.Level).HasColumnName("level");

                entity.Property(e => e.SchemaName)
                    .IsRequired()
                    .HasColumnName("schema_name")
                    .HasColumnType("character varying");

                entity.Property(e => e.TableName)
                    .IsRequired()
                    .HasColumnName("table_name")
                    .HasColumnType("character varying");

                entity.HasOne(d => d.Topology)
                    .WithMany(p => p.Layer)
                    .HasForeignKey(d => d.TopologyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("layer_topology_id_fkey");
            });

            modelBuilder.Entity<LoaderLookuptables>(entity =>
            {
                entity.HasKey(e => e.LookupName)
                    .HasName("loader_lookuptables_pkey");

                entity.ToTable("loader_lookuptables", "tiger");

                entity.Property(e => e.LookupName)
                    .HasColumnName("lookup_name")
                    .ValueGeneratedNever()
                    .ForNpgsqlHasComment("This is the table name to inherit from and suffix of resulting output table -- how the table will be named --  edges here would mean -- ma_edges , pa_edges etc. except in the case of national tables. national level tables have no prefix");

                entity.Property(e => e.ColumnsExclude)
                    .HasColumnName("columns_exclude")
                    .ForNpgsqlHasComment("List of columns to exclude as an array. This is excluded from both input table and output table and rest of columns remaining are assumed to be in same order in both tables. gid, geoid,cpi,suffix1ce are excluded if no columns are specified.");

                entity.Property(e => e.InsertMode)
                    .HasColumnName("insert_mode")
                    .HasDefaultValueSql("'c'::bpchar");

                entity.Property(e => e.LevelCounty).HasColumnName("level_county");

                entity.Property(e => e.LevelNation)
                    .HasColumnName("level_nation")
                    .ForNpgsqlHasComment("These are tables that contain all data for the whole US so there is just a single file");

                entity.Property(e => e.LevelState).HasColumnName("level_state");

                entity.Property(e => e.Load)
                    .IsRequired()
                    .HasColumnName("load")
                    .HasDefaultValueSql("true")
                    .ForNpgsqlHasComment("Whether or not to load the table.  For states and zcta5 (you may just want to download states10, zcta510 nationwide file manually) load your own into a single table that inherits from tiger.states, tiger.zcta5.  You'll get improved performance for some geocoding cases.");

                entity.Property(e => e.PostLoadProcess).HasColumnName("post_load_process");

                entity.Property(e => e.PreLoadProcess).HasColumnName("pre_load_process");

                entity.Property(e => e.ProcessOrder)
                    .HasColumnName("process_order")
                    .HasDefaultValueSql("1000");

                entity.Property(e => e.SingleGeomMode)
                    .HasColumnName("single_geom_mode")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.SingleMode)
                    .IsRequired()
                    .HasColumnName("single_mode")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.TableName)
                    .HasColumnName("table_name")
                    .ForNpgsqlHasComment("suffix of the tables to load e.g.  edges would load all tables like *edges.dbf(shp)  -- so tl_2010_42129_edges.dbf .  ");

                entity.Property(e => e.WebsiteRootOverride)
                    .HasColumnName("website_root_override")
                    .ForNpgsqlHasComment("Path to use for wget instead of that specified in year table.  Needed currently for zcta where they release that only for 2000 and 2010");
            });

            modelBuilder.Entity<LoaderPlatform>(entity =>
            {
                entity.HasKey(e => e.Os)
                    .HasName("loader_platform_pkey");

                entity.ToTable("loader_platform", "tiger");

                entity.Property(e => e.Os)
                    .HasColumnName("os")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.CountyProcessCommand).HasColumnName("county_process_command");

                entity.Property(e => e.DeclareSect).HasColumnName("declare_sect");

                entity.Property(e => e.EnvironSetCommand).HasColumnName("environ_set_command");

                entity.Property(e => e.Loader).HasColumnName("loader");

                entity.Property(e => e.PathSep).HasColumnName("path_sep");

                entity.Property(e => e.Pgbin).HasColumnName("pgbin");

                entity.Property(e => e.Psql).HasColumnName("psql");

                entity.Property(e => e.UnzipCommand).HasColumnName("unzip_command");

                entity.Property(e => e.Wget).HasColumnName("wget");
            });

            modelBuilder.Entity<LoaderVariables>(entity =>
            {
                entity.HasKey(e => e.TigerYear)
                    .HasName("loader_variables_pkey");

                entity.ToTable("loader_variables", "tiger");

                entity.Property(e => e.TigerYear)
                    .HasColumnName("tiger_year")
                    .HasMaxLength(4)
                    .ValueGeneratedNever();

                entity.Property(e => e.DataSchema).HasColumnName("data_schema");

                entity.Property(e => e.StagingFold).HasColumnName("staging_fold");

                entity.Property(e => e.StagingSchema).HasColumnName("staging_schema");

                entity.Property(e => e.WebsiteRoot).HasColumnName("website_root");
            });

            modelBuilder.Entity<PagcGaz>(entity =>
            {
                entity.ToTable("pagc_gaz", "tiger");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IsCustom)
                    .IsRequired()
                    .HasColumnName("is_custom")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Seq).HasColumnName("seq");

                entity.Property(e => e.Stdword).HasColumnName("stdword");

                entity.Property(e => e.Token).HasColumnName("token");

                entity.Property(e => e.Word).HasColumnName("word");
            });

            modelBuilder.Entity<PagcLex>(entity =>
            {
                entity.ToTable("pagc_lex", "tiger");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IsCustom)
                    .IsRequired()
                    .HasColumnName("is_custom")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Seq).HasColumnName("seq");

                entity.Property(e => e.Stdword).HasColumnName("stdword");

                entity.Property(e => e.Token).HasColumnName("token");

                entity.Property(e => e.Word).HasColumnName("word");
            });

            modelBuilder.Entity<PagcRules>(entity =>
            {
                entity.ToTable("pagc_rules", "tiger");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IsCustom)
                    .HasColumnName("is_custom")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Rule).HasColumnName("rule");
            });

            modelBuilder.Entity<Place>(entity =>
            {
                entity.HasKey(e => e.Plcidfp)
                    .HasName("place_pkey");

                entity.ToTable("place", "tiger");

                entity.HasIndex(e => e.Gid)
                    .HasName("uidx_tiger_place_gid")
                    .IsUnique();

                entity.Property(e => e.Plcidfp)
                    .HasColumnName("plcidfp")
                    .HasMaxLength(7)
                    .ValueGeneratedNever();

                entity.Property(e => e.Aland).HasColumnName("aland");

                entity.Property(e => e.Awater).HasColumnName("awater");

                entity.Property(e => e.Classfp)
                    .HasColumnName("classfp")
                    .HasMaxLength(2);

                entity.Property(e => e.Cpi)
                    .HasColumnName("cpi")
                    .HasMaxLength(1);

                entity.Property(e => e.Funcstat)
                    .HasColumnName("funcstat")
                    .HasMaxLength(1);

                entity.Property(e => e.Gid)
                    .HasColumnName("gid")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Intptlat)
                    .HasColumnName("intptlat")
                    .HasMaxLength(11);

                entity.Property(e => e.Intptlon)
                    .HasColumnName("intptlon")
                    .HasMaxLength(12);

                entity.Property(e => e.Lsad)
                    .HasColumnName("lsad")
                    .HasMaxLength(2);

                entity.Property(e => e.Mtfcc)
                    .HasColumnName("mtfcc")
                    .HasMaxLength(5);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100);

                entity.Property(e => e.Namelsad)
                    .HasColumnName("namelsad")
                    .HasMaxLength(100);

                entity.Property(e => e.Pcicbsa)
                    .HasColumnName("pcicbsa")
                    .HasMaxLength(1);

                entity.Property(e => e.Pcinecta)
                    .HasColumnName("pcinecta")
                    .HasMaxLength(1);

                entity.Property(e => e.Placefp)
                    .HasColumnName("placefp")
                    .HasMaxLength(5);

                entity.Property(e => e.Placens)
                    .HasColumnName("placens")
                    .HasMaxLength(8);

                entity.Property(e => e.Statefp)
                    .HasColumnName("statefp")
                    .HasMaxLength(2);
            });

            modelBuilder.Entity<PlaceLookup>(entity =>
            {
                entity.HasKey(e => new { e.StCode, e.PlCode })
                    .HasName("place_lookup_pkey");

                entity.ToTable("place_lookup", "tiger");

                entity.HasIndex(e => e.State)
                    .HasName("place_lookup_state_idx");

                entity.Property(e => e.StCode).HasColumnName("st_code");

                entity.Property(e => e.PlCode).HasColumnName("pl_code");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(90);

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasMaxLength(2);
            });

            modelBuilder.Entity<PointcloudFormats>(entity =>
            {
                entity.HasKey(e => e.Pcid)
                    .HasName("pointcloud_formats_pkey");

                entity.ToTable("pointcloud_formats");

                entity.Property(e => e.Pcid)
                    .HasColumnName("pcid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Schema).HasColumnName("schema");

                entity.Property(e => e.Srid).HasColumnName("srid");
            });

            modelBuilder.Entity<SecondaryUnitLookup>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("secondary_unit_lookup_pkey");

                entity.ToTable("secondary_unit_lookup", "tiger");

                entity.HasIndex(e => e.Abbrev)
                    .HasName("secondary_unit_lookup_abbrev_idx");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(20)
                    .ValueGeneratedNever();

                entity.Property(e => e.Abbrev)
                    .HasColumnName("abbrev")
                    .HasMaxLength(5);
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.HasKey(e => e.Statefp)
                    .HasName("pk_tiger_state");

                entity.ToTable("state", "tiger");

                entity.HasIndex(e => e.Gid)
                    .HasName("uidx_tiger_state_gid")
                    .IsUnique();

                entity.HasIndex(e => e.Stusps)
                    .HasName("uidx_tiger_state_stusps")
                    .IsUnique();

                entity.Property(e => e.Statefp)
                    .HasColumnName("statefp")
                    .HasMaxLength(2)
                    .ValueGeneratedNever();

                entity.Property(e => e.Aland).HasColumnName("aland");

                entity.Property(e => e.Awater).HasColumnName("awater");

                entity.Property(e => e.Division)
                    .HasColumnName("division")
                    .HasMaxLength(2);

                entity.Property(e => e.Funcstat)
                    .HasColumnName("funcstat")
                    .HasMaxLength(1);

                entity.Property(e => e.Gid)
                    .HasColumnName("gid")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Intptlat)
                    .HasColumnName("intptlat")
                    .HasMaxLength(11);

                entity.Property(e => e.Intptlon)
                    .HasColumnName("intptlon")
                    .HasMaxLength(12);

                entity.Property(e => e.Lsad)
                    .HasColumnName("lsad")
                    .HasMaxLength(2);

                entity.Property(e => e.Mtfcc)
                    .HasColumnName("mtfcc")
                    .HasMaxLength(5);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100);

                entity.Property(e => e.Region)
                    .HasColumnName("region")
                    .HasMaxLength(2);

                entity.Property(e => e.Statens)
                    .HasColumnName("statens")
                    .HasMaxLength(8);

                entity.Property(e => e.Stusps)
                    .IsRequired()
                    .HasColumnName("stusps")
                    .HasMaxLength(2);
            });

            modelBuilder.Entity<StateLookup>(entity =>
            {
                entity.HasKey(e => e.StCode)
                    .HasName("state_lookup_pkey");

                entity.ToTable("state_lookup", "tiger");

                entity.HasIndex(e => e.Abbrev)
                    .HasName("state_lookup_abbrev_key")
                    .IsUnique();

                entity.HasIndex(e => e.Name)
                    .HasName("state_lookup_name_key")
                    .IsUnique();

                entity.HasIndex(e => e.Statefp)
                    .HasName("state_lookup_statefp_key")
                    .IsUnique();

                entity.Property(e => e.StCode)
                    .HasColumnName("st_code")
                    .ValueGeneratedNever();

                entity.Property(e => e.Abbrev)
                    .HasColumnName("abbrev")
                    .HasMaxLength(3);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(40);

                entity.Property(e => e.Statefp)
                    .HasColumnName("statefp")
                    .HasColumnType("character(2)");
            });

            modelBuilder.Entity<StreetTypeLookup>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("street_type_lookup_pkey");

                entity.ToTable("street_type_lookup", "tiger");

                entity.HasIndex(e => e.Abbrev)
                    .HasName("street_type_lookup_abbrev_idx");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.Abbrev)
                    .HasColumnName("abbrev")
                    .HasMaxLength(50);

                entity.Property(e => e.IsHw).HasColumnName("is_hw");
            });

            modelBuilder.Entity<Tabblock>(entity =>
            {
                entity.ToTable("tabblock", "tiger");

                entity.Property(e => e.TabblockId)
                    .HasColumnName("tabblock_id")
                    .HasMaxLength(16)
                    .ValueGeneratedNever();

                entity.Property(e => e.Aland).HasColumnName("aland");

                entity.Property(e => e.Awater).HasColumnName("awater");

                entity.Property(e => e.Blockce)
                    .HasColumnName("blockce")
                    .HasMaxLength(4);

                entity.Property(e => e.Countyfp)
                    .HasColumnName("countyfp")
                    .HasMaxLength(3);

                entity.Property(e => e.Funcstat)
                    .HasColumnName("funcstat")
                    .HasMaxLength(1);

                entity.Property(e => e.Gid)
                    .HasColumnName("gid")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Intptlat)
                    .HasColumnName("intptlat")
                    .HasMaxLength(11);

                entity.Property(e => e.Intptlon)
                    .HasColumnName("intptlon")
                    .HasMaxLength(12);

                entity.Property(e => e.Mtfcc)
                    .HasColumnName("mtfcc")
                    .HasMaxLength(5);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(20);

                entity.Property(e => e.Statefp)
                    .HasColumnName("statefp")
                    .HasMaxLength(2);

                entity.Property(e => e.Tractce)
                    .HasColumnName("tractce")
                    .HasMaxLength(6);

                entity.Property(e => e.Uace)
                    .HasColumnName("uace")
                    .HasMaxLength(5);

                entity.Property(e => e.Ur)
                    .HasColumnName("ur")
                    .HasMaxLength(1);
            });

            modelBuilder.Entity<Testrocks>(entity =>
            {
                entity.HasKey(e => e.Gid)
                    .HasName("testrocks_pkey");

                entity.ToTable("testrocks");

                entity.Property(e => e.Gid).HasColumnName("gid");

                entity.Property(e => e.Latitude)
                    .HasColumnName("latitude")
                    .HasColumnType("numeric(12,8)");

                entity.Property(e => e.Longitude)
                    .HasColumnName("longitude")
                    .HasColumnType("numeric(12,8)");

                entity.Property(e => e.Mineral).HasColumnName("mineral");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Occurence)
                    .HasColumnName("occurence")
                    .HasMaxLength(50);

                entity.Property(e => e.Raregems).HasColumnName("raregems");
            });

            modelBuilder.Entity<Topology>(entity =>
            {
                entity.ToTable("topology", "topology");

                entity.HasIndex(e => e.Name)
                    .HasName("topology_name_key")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('topology.topology_id_seq'::regclass)");

                entity.Property(e => e.Hasz).HasColumnName("hasz");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("character varying");

                entity.Property(e => e.Precision).HasColumnName("precision");

                entity.Property(e => e.Srid).HasColumnName("srid");
            });

            modelBuilder.Entity<Tract>(entity =>
            {
                entity.ToTable("tract", "tiger");

                entity.Property(e => e.TractId)
                    .HasColumnName("tract_id")
                    .HasMaxLength(11)
                    .ValueGeneratedNever();

                entity.Property(e => e.Aland).HasColumnName("aland");

                entity.Property(e => e.Awater).HasColumnName("awater");

                entity.Property(e => e.Countyfp)
                    .HasColumnName("countyfp")
                    .HasMaxLength(3);

                entity.Property(e => e.Funcstat)
                    .HasColumnName("funcstat")
                    .HasMaxLength(1);

                entity.Property(e => e.Gid)
                    .HasColumnName("gid")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Intptlat)
                    .HasColumnName("intptlat")
                    .HasMaxLength(11);

                entity.Property(e => e.Intptlon)
                    .HasColumnName("intptlon")
                    .HasMaxLength(12);

                entity.Property(e => e.Mtfcc)
                    .HasColumnName("mtfcc")
                    .HasMaxLength(5);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(7);

                entity.Property(e => e.Namelsad)
                    .HasColumnName("namelsad")
                    .HasMaxLength(20);

                entity.Property(e => e.Statefp)
                    .HasColumnName("statefp")
                    .HasMaxLength(2);

                entity.Property(e => e.Tractce)
                    .HasColumnName("tractce")
                    .HasMaxLength(6);
            });

            modelBuilder.Entity<UsGaz>(entity =>
            {
                entity.ToTable("us_gaz");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IsCustom)
                    .IsRequired()
                    .HasColumnName("is_custom")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Seq).HasColumnName("seq");

                entity.Property(e => e.Stdword).HasColumnName("stdword");

                entity.Property(e => e.Token).HasColumnName("token");

                entity.Property(e => e.Word).HasColumnName("word");
            });

            modelBuilder.Entity<UsLex>(entity =>
            {
                entity.ToTable("us_lex");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IsCustom)
                    .IsRequired()
                    .HasColumnName("is_custom")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Seq).HasColumnName("seq");

                entity.Property(e => e.Stdword).HasColumnName("stdword");

                entity.Property(e => e.Token).HasColumnName("token");

                entity.Property(e => e.Word).HasColumnName("word");
            });

            modelBuilder.Entity<UsRules>(entity =>
            {
                entity.ToTable("us_rules");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IsCustom)
                    .IsRequired()
                    .HasColumnName("is_custom")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Rule).HasColumnName("rule");
            });

            modelBuilder.Entity<Zcta5>(entity =>
            {
                entity.HasKey(e => new { e.Zcta5ce, e.Statefp })
                    .HasName("pk_tiger_zcta5_zcta5ce");

                entity.ToTable("zcta5", "tiger");

                entity.HasIndex(e => e.Gid)
                    .HasName("uidx_tiger_zcta5_gid")
                    .IsUnique();

                entity.Property(e => e.Zcta5ce)
                    .HasColumnName("zcta5ce")
                    .HasMaxLength(5);

                entity.Property(e => e.Statefp)
                    .HasColumnName("statefp")
                    .HasMaxLength(2);

                entity.Property(e => e.Aland).HasColumnName("aland");

                entity.Property(e => e.Awater).HasColumnName("awater");

                entity.Property(e => e.Classfp)
                    .HasColumnName("classfp")
                    .HasMaxLength(2);

                entity.Property(e => e.Funcstat)
                    .HasColumnName("funcstat")
                    .HasMaxLength(1);

                entity.Property(e => e.Gid)
                    .HasColumnName("gid")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Intptlat)
                    .HasColumnName("intptlat")
                    .HasMaxLength(11);

                entity.Property(e => e.Intptlon)
                    .HasColumnName("intptlon")
                    .HasMaxLength(12);

                entity.Property(e => e.Mtfcc)
                    .HasColumnName("mtfcc")
                    .HasMaxLength(5);

                entity.Property(e => e.Partflg)
                    .HasColumnName("partflg")
                    .HasMaxLength(1);
            });

            modelBuilder.Entity<ZipLookup>(entity =>
            {
                entity.HasKey(e => e.Zip)
                    .HasName("zip_lookup_pkey");

                entity.ToTable("zip_lookup", "tiger");

                entity.Property(e => e.Zip)
                    .HasColumnName("zip")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cnt).HasColumnName("cnt");

                entity.Property(e => e.CoCode).HasColumnName("co_code");

                entity.Property(e => e.County)
                    .HasColumnName("county")
                    .HasMaxLength(90);

                entity.Property(e => e.Cousub)
                    .HasColumnName("cousub")
                    .HasMaxLength(90);

                entity.Property(e => e.CsCode).HasColumnName("cs_code");

                entity.Property(e => e.PlCode).HasColumnName("pl_code");

                entity.Property(e => e.Place)
                    .HasColumnName("place")
                    .HasMaxLength(90);

                entity.Property(e => e.StCode).HasColumnName("st_code");

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasMaxLength(2);
            });

            modelBuilder.Entity<ZipLookupBase>(entity =>
            {
                entity.HasKey(e => e.Zip)
                    .HasName("zip_lookup_base_pkey");

                entity.ToTable("zip_lookup_base", "tiger");

                entity.Property(e => e.Zip)
                    .HasColumnName("zip")
                    .HasMaxLength(5)
                    .ValueGeneratedNever();

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(90);

                entity.Property(e => e.County)
                    .HasColumnName("county")
                    .HasMaxLength(90);

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasMaxLength(40);

                entity.Property(e => e.Statefp)
                    .HasColumnName("statefp")
                    .HasMaxLength(2);
            });

            modelBuilder.Entity<ZipState>(entity =>
            {
                entity.HasKey(e => new { e.Zip, e.Stusps })
                    .HasName("zip_state_pkey");

                entity.ToTable("zip_state", "tiger");

                entity.Property(e => e.Zip)
                    .HasColumnName("zip")
                    .HasMaxLength(5);

                entity.Property(e => e.Stusps)
                    .HasColumnName("stusps")
                    .HasMaxLength(2);

                entity.Property(e => e.Statefp)
                    .HasColumnName("statefp")
                    .HasMaxLength(2);
            });

            modelBuilder.Entity<ZipStateLoc>(entity =>
            {
                entity.HasKey(e => new { e.Zip, e.Stusps, e.Place })
                    .HasName("zip_state_loc_pkey");

                entity.ToTable("zip_state_loc", "tiger");

                entity.Property(e => e.Zip)
                    .HasColumnName("zip")
                    .HasMaxLength(5);

                entity.Property(e => e.Stusps)
                    .HasColumnName("stusps")
                    .HasMaxLength(2);

                entity.Property(e => e.Place)
                    .HasColumnName("place")
                    .HasMaxLength(100);

                entity.Property(e => e.Statefp)
                    .HasColumnName("statefp")
                    .HasMaxLength(2);
            });

            modelBuilder.HasSequence<int>("topology_id_seq");
        }
    }
}
