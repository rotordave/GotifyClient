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
    /// The MessageExternal holds information about a message which was sent by an Application.
    /// </summary>
    [DataContract]
    public partial class Message :  IEquatable<Message>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Message" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected Message() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Message" /> class.
        /// </summary>
        /// <param name="extras">The extra data sent along the message.  The extra fields are stored in a key-value scheme. Only accepted in CreateMessage requests with application/json content-type.  The keys should be in the following format: &amp;lt;top-namespace&amp;gt;::[&amp;lt;sub-namespace&amp;gt;::]&amp;lt;action&amp;gt;  These namespaces are reserved and might be used in the official clients: gotify android ios web server client. Do not use them for other purposes..</param>
        /// <param name="message">The message. Markdown (excluding html) is allowed. (required).</param>
        /// <param name="priority">The priority of the message..</param>
        /// <param name="title">The title of the message..</param>
        public Message(Dictionary<string, Object> extras = default(Dictionary<string, Object>), string message = default(string), long? priority = default(long?), string title = default(string))
        {
            // to ensure "message" is required (not null)
            if (message == null)
            {
                throw new InvalidDataException("message is a required property for Message and cannot be null");
            }
            else
            {
                this._Message = message;
            }
            this.Extras = extras;
            this.Priority = priority;
            this.Title = title;
        }
        
        /// <summary>
        /// The application id that send this message.
        /// </summary>
        /// <value>The application id that send this message.</value>
        [DataMember(Name="appid", EmitDefaultValue=false)]
        public int? Appid { get; private set; }

        /// <summary>
        /// The date the message was created.
        /// </summary>
        /// <value>The date the message was created.</value>
        [DataMember(Name="date", EmitDefaultValue=false)]
        public DateTime? Date { get; private set; }

        /// <summary>
        /// The extra data sent along the message.  The extra fields are stored in a key-value scheme. Only accepted in CreateMessage requests with application/json content-type.  The keys should be in the following format: &amp;lt;top-namespace&amp;gt;::[&amp;lt;sub-namespace&amp;gt;::]&amp;lt;action&amp;gt;  These namespaces are reserved and might be used in the official clients: gotify android ios web server client. Do not use them for other purposes.
        /// </summary>
        /// <value>The extra data sent along the message.  The extra fields are stored in a key-value scheme. Only accepted in CreateMessage requests with application/json content-type.  The keys should be in the following format: &amp;lt;top-namespace&amp;gt;::[&amp;lt;sub-namespace&amp;gt;::]&amp;lt;action&amp;gt;  These namespaces are reserved and might be used in the official clients: gotify android ios web server client. Do not use them for other purposes.</value>
        [DataMember(Name="extras", EmitDefaultValue=false)]
        public Dictionary<string, Object> Extras { get; set; }

        /// <summary>
        /// The message id.
        /// </summary>
        /// <value>The message id.</value>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public int? Id { get; private set; }

        /// <summary>
        /// The message. Markdown (excluding html) is allowed.
        /// </summary>
        /// <value>The message. Markdown (excluding html) is allowed.</value>
        [DataMember(Name="message", EmitDefaultValue=false)]
        public string _Message { get; set; }

        /// <summary>
        /// The priority of the message.
        /// </summary>
        /// <value>The priority of the message.</value>
        [DataMember(Name="priority", EmitDefaultValue=false)]
        public long? Priority { get; set; }

        /// <summary>
        /// The title of the message.
        /// </summary>
        /// <value>The title of the message.</value>
        [DataMember(Name="title", EmitDefaultValue=false)]
        public string Title { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Message {\n");
            sb.Append("  Appid: ").Append(Appid).Append("\n");
            sb.Append("  Date: ").Append(Date).Append("\n");
            sb.Append("  Extras: ").Append(Extras).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  _Message: ").Append(_Message).Append("\n");
            sb.Append("  Priority: ").Append(Priority).Append("\n");
            sb.Append("  Title: ").Append(Title).Append("\n");
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
            return this.Equals(input as Message);
        }

        /// <summary>
        /// Returns true if Message instances are equal
        /// </summary>
        /// <param name="input">Instance of Message to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Message input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Appid == input.Appid ||
                    (this.Appid != null &&
                    this.Appid.Equals(input.Appid))
                ) && 
                (
                    this.Date == input.Date ||
                    (this.Date != null &&
                    this.Date.Equals(input.Date))
                ) && 
                (
                    this.Extras == input.Extras ||
                    this.Extras != null &&
                    this.Extras.SequenceEqual(input.Extras)
                ) && 
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
                ) && 
                (
                    this._Message == input._Message ||
                    (this._Message != null &&
                    this._Message.Equals(input._Message))
                ) && 
                (
                    this.Priority == input.Priority ||
                    (this.Priority != null &&
                    this.Priority.Equals(input.Priority))
                ) && 
                (
                    this.Title == input.Title ||
                    (this.Title != null &&
                    this.Title.Equals(input.Title))
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
                if (this.Appid != null)
                    hashCode = hashCode * 59 + this.Appid.GetHashCode();
                if (this.Date != null)
                    hashCode = hashCode * 59 + this.Date.GetHashCode();
                if (this.Extras != null)
                    hashCode = hashCode * 59 + this.Extras.GetHashCode();
                if (this.Id != null)
                    hashCode = hashCode * 59 + this.Id.GetHashCode();
                if (this._Message != null)
                    hashCode = hashCode * 59 + this._Message.GetHashCode();
                if (this.Priority != null)
                    hashCode = hashCode * 59 + this.Priority.GetHashCode();
                if (this.Title != null)
                    hashCode = hashCode * 59 + this.Title.GetHashCode();
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
