/* 
 * Gotify REST-API.
 *
 * This is the documentation of the Gotify REST-API.  # Authentication In Gotify there are two token types: __clientToken__: a client is something that receives message and manages stuff like creating new tokens or delete messages. (f.ex this token should be used for an android app) __appToken__: an application is something that sends messages (f.ex. this token should be used for a shell script)  The token can be either transmitted through a header named `X-Gotify-Key` or a query parameter named `token`. There is also the possibility to authenticate through basic auth, this should only be used for creating a clientToken.  \\- --  Found a bug or have some questions? [Create an issue on GitHub](https://github.com/gotify/server/issues)
 *
 * OpenAPI spec version: 2.0.1
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using SwaggerDateConverter = IO.Swagger.Client.SwaggerDateConverter;

namespace IO.Swagger.Model
{
    /// <summary>
    /// Health represents how healthy the application is.
    /// </summary>
    [DataContract]
    public partial class Health :  IEquatable<Health>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Health" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected Health() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Health" /> class.
        /// </summary>
        /// <param name="database">The health of the database connection. (required).</param>
        /// <param name="health">The health of the overall application. (required).</param>
        public Health(string database = default(string), string health = default(string))
        {
            // to ensure "database" is required (not null)
            if (database == null)
            {
                throw new InvalidDataException("database is a required property for Health and cannot be null");
            }
            else
            {
                this.Database = database;
            }
            // to ensure "health" is required (not null)
            if (health == null)
            {
                throw new InvalidDataException("health is a required property for Health and cannot be null");
            }
            else
            {
                this._Health = health;
            }
        }
        
        /// <summary>
        /// The health of the database connection.
        /// </summary>
        /// <value>The health of the database connection.</value>
        [DataMember(Name="database", EmitDefaultValue=false)]
        public string Database { get; set; }

        /// <summary>
        /// The health of the overall application.
        /// </summary>
        /// <value>The health of the overall application.</value>
        [DataMember(Name="health", EmitDefaultValue=false)]
        public string _Health { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Health {\n");
            sb.Append("  Database: ").Append(Database).Append("\n");
            sb.Append("  _Health: ").Append(_Health).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as Health);
        }

        /// <summary>
        /// Returns true if Health instances are equal
        /// </summary>
        /// <param name="input">Instance of Health to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Health input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Database == input.Database ||
                    (this.Database != null &&
                    this.Database.Equals(input.Database))
                ) && 
                (
                    this._Health == input._Health ||
                    (this._Health != null &&
                    this._Health.Equals(input._Health))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.Database != null)
                    hashCode = hashCode * 59 + this.Database.GetHashCode();
                if (this._Health != null)
                    hashCode = hashCode * 59 + this._Health.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}
