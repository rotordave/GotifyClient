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
    /// VersionInfo Model
    /// </summary>
    [DataContract]
    public partial class VersionInfo :  IEquatable<VersionInfo>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VersionInfo" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected VersionInfo() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="VersionInfo" /> class.
        /// </summary>
        /// <param name="buildDate">The date on which this binary was built. (required).</param>
        /// <param name="commit">The git commit hash on which this binary was built. (required).</param>
        /// <param name="version">The current version. (required).</param>
        public VersionInfo(string buildDate = default(string), string commit = default(string), string version = default(string))
        {
            // to ensure "buildDate" is required (not null)
            if (buildDate == null)
            {
                throw new InvalidDataException("buildDate is a required property for VersionInfo and cannot be null");
            }
            else
            {
                this.BuildDate = buildDate;
            }
            // to ensure "commit" is required (not null)
            if (commit == null)
            {
                throw new InvalidDataException("commit is a required property for VersionInfo and cannot be null");
            }
            else
            {
                this.Commit = commit;
            }
            // to ensure "version" is required (not null)
            if (version == null)
            {
                throw new InvalidDataException("version is a required property for VersionInfo and cannot be null");
            }
            else
            {
                this.Version = version;
            }
        }
        
        /// <summary>
        /// The date on which this binary was built.
        /// </summary>
        /// <value>The date on which this binary was built.</value>
        [DataMember(Name="buildDate", EmitDefaultValue=false)]
        public string BuildDate { get; set; }

        /// <summary>
        /// The git commit hash on which this binary was built.
        /// </summary>
        /// <value>The git commit hash on which this binary was built.</value>
        [DataMember(Name="commit", EmitDefaultValue=false)]
        public string Commit { get; set; }

        /// <summary>
        /// The current version.
        /// </summary>
        /// <value>The current version.</value>
        [DataMember(Name="version", EmitDefaultValue=false)]
        public string Version { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class VersionInfo {\n");
            sb.Append("  BuildDate: ").Append(BuildDate).Append("\n");
            sb.Append("  Commit: ").Append(Commit).Append("\n");
            sb.Append("  Version: ").Append(Version).Append("\n");
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
            return this.Equals(input as VersionInfo);
        }

        /// <summary>
        /// Returns true if VersionInfo instances are equal
        /// </summary>
        /// <param name="input">Instance of VersionInfo to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(VersionInfo input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.BuildDate == input.BuildDate ||
                    (this.BuildDate != null &&
                    this.BuildDate.Equals(input.BuildDate))
                ) && 
                (
                    this.Commit == input.Commit ||
                    (this.Commit != null &&
                    this.Commit.Equals(input.Commit))
                ) && 
                (
                    this.Version == input.Version ||
                    (this.Version != null &&
                    this.Version.Equals(input.Version))
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
                if (this.BuildDate != null)
                    hashCode = hashCode * 59 + this.BuildDate.GetHashCode();
                if (this.Commit != null)
                    hashCode = hashCode * 59 + this.Commit.GetHashCode();
                if (this.Version != null)
                    hashCode = hashCode * 59 + this.Version.GetHashCode();
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
