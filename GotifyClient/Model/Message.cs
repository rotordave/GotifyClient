

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GotifyClient.Model
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
                this.MessageContent = message;
            }
            this.Extras = extras;
            this.Priority = priority;
            this.Title = title;
        }
        
        /// <summary>
        /// The application id that send this message.
        /// </summary>
        /// <value>The application id that send this message.</value>
        //[JsonPropertyName("appid")]
        [JsonPropertyName("appid")]
        public int? Appid { get; set; }

        /// <summary>
        /// The date the message was created.
        /// </summary>
        /// <value>The date the message was created.</value>
        [JsonPropertyName("date")]
        public DateTime? Date { get; set; }

        /// <summary>
        /// The extra data sent along the message.  The extra fields are stored in a key-value scheme. Only accepted in CreateMessage requests with application/json content-type.  The keys should be in the following format: &amp;lt;top-namespace&amp;gt;::[&amp;lt;sub-namespace&amp;gt;::]&amp;lt;action&amp;gt;  These namespaces are reserved and might be used in the official clients: gotify android ios web server client. Do not use them for other purposes.
        /// </summary>
        /// <value>The extra data sent along the message.  The extra fields are stored in a key-value scheme. Only accepted in CreateMessage requests with application/json content-type.  The keys should be in the following format: &amp;lt;top-namespace&amp;gt;::[&amp;lt;sub-namespace&amp;gt;::]&amp;lt;action&amp;gt;  These namespaces are reserved and might be used in the official clients: gotify android ios web server client. Do not use them for other purposes.</value>
        [JsonPropertyName("extras")]
        public Dictionary<string, Object> Extras { get; set; }

        /// <summary>
        /// The message id.
        /// </summary>
        /// <value>The message id.</value>
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        /// <summary>
        /// The message. Markdown (excluding html) is allowed.
        /// </summary>
        /// <value>The message. Markdown (excluding html) is allowed.</value>
        [JsonPropertyName("message")]
        public string MessageContent { get; set; }

        /// <summary>
        /// The priority of the message.
        /// </summary>
        /// <value>The priority of the message.</value>
        [JsonPropertyName("priority")]
        public long? Priority { get; set; }

        /// <summary>
        /// The title of the message.
        /// </summary>
        /// <value>The title of the message.</value>
        [JsonPropertyName("title")]
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
            sb.Append("  MessageContent: ").Append(MessageContent).Append("\n");
            sb.Append("  Priority: ").Append(Priority).Append("\n");
            sb.Append("  Title: ").Append(Title).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        //public virtual string ToJson()
        //{
        //    return JsonConvert.SerializeObject(this, Formatting.Indented);
        //}

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
                    this.MessageContent == input.MessageContent ||
                    (this.MessageContent != null &&
                    this.MessageContent.Equals(input.MessageContent))
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
                if (this.MessageContent != null)
                    hashCode = hashCode * 59 + this.MessageContent.GetHashCode();
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
