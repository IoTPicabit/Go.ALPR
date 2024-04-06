using System;

namespace Go.ALPR.Sri.Common
{
    public class Enums
    {
        /// <summary>
        /// Dictionary types to return
        /// </summary>
        public enum DictionaryReturnType
        {
            KeyOnly,
            ValueOnly,
            KeyAndValue,
        }

        /// <summary>
        /// Repository source type
        /// </summary>
        public enum RepositorySource
        {
            AmazonDynamoDB,
            AmazonRedShift,
            Cassandra,
            CouchDB,
            CouchBase,
            DBase,
            DB2,
            Ehcache,
            ElastiSearch,
            Endeca,
            EntityFramework,
            FileMaker,
            FireBird,
            GreenPlum,
            HBase,
            Hive,
            Informix,
            Ingres,
            LinqToSQL,
            MarkLogic,
            MariaDB,
            MemCached,
            MySQL,
            MicrosoftAzureSQLDatabase,
            MicrosoftAccess,
            MicrosoftSQLServer,
            Mock,
            MongoDB,
            Netazza,
            Neo4j,
            Oracle,
            PostgreSQL,
            Redis,
            Riak,
            SAPAdaptiveServer,
            SAPHana,
            Solr,
            Sphinx,
            Splunk,
            SQLite,
            TeraData,
            Vertica,
        }
    
        public enum TipoIdentificacion
        {
            Entrada = 1,
            Salida = 2
        }

        public enum TipoEstado
        {
            Inicial = 0,
            Enterado = 10,
            Correcto = 20,
            Fallo = 30,
            SistemaApagado = 40
        }

        public enum TipoUsuario
        {
            Administrador = 1,
            Operario = 2
        }

        public enum TipoOperacion
        {
            Carga = 1,
            Descarga = 2
        }
    
    }
}
