﻿namespace Boilerplate.Web.Mvc.OpenGraph
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// This object type represents a TV show, and contains references to the actors and other professionals involved in its production. For individual
    /// episodes of a series, use the video.episode object type. A TV show is defined by us as a series or set of episodes that are produced under the
    /// same title (eg. a television or online series). This object type is part of the Open Graph standard.
    /// See http://ogp.me/
    /// See https://developers.facebook.com/docs/reference/opengraph/object-type/video.tv_show/
    /// </summary>
    public class OpenGraphVideoTvShow : OpenGraphMetadata
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OpenGraphVideoTvShow"/> class.
        /// </summary>
        /// <param name="title">The title of the object as it should appear in the graph.</param>
        /// <param name="image">The default image.</param>
        /// <param name="url">The canonical URL of the object, used as its ID in the graph.</param>
        public OpenGraphVideoTvShow(string title, OpenGraphImage image, string url = null)
            : base(title, image, url)
        {
        }

        /// <summary>
        /// Gets or sets the actors in the television show.
        /// </summary>
        public IEnumerable<OpenGraphActor> Actors { get; set; }

        /// <summary>
        /// Gets or sets the URL's to the pages about the directors. This URL's must contain profile meta tags <see cref="OpenGraphProfile"/>.
        /// </summary>
        public IEnumerable<string> DirectorUrls { get; set; }

        /// <summary>
        /// Gets or sets the duration of the television show in seconds.
        /// </summary>
        public int? Duration { get; set; }

        /// <summary>
        /// Gets the namespace of this open graph type.
        /// </summary>
        public override string Namespace => "video: http://ogp.me/ns/video#";

        /// <summary>
        /// Gets or sets the release date of the television show.
        /// </summary>
        public DateTime? ReleaseDate { get; set; }

        /// <summary>
        /// Gets or sets the tag words associated with the television show.
        /// </summary>
        public IEnumerable<string> Tags { get; set; }

        /// <summary>
        /// Gets the type of your object. Depending on the type you specify, other properties may also be required.
        /// </summary>
        public override OpenGraphType Type => OpenGraphType.VideoTvShow;

        /// <summary>
        /// Gets or sets the URL's to the pages about the writers. This URL's must contain profile meta tags <see cref="OpenGraphProfile"/>.
        /// </summary>
        public IEnumerable<string> WriterUrls { get; set; }

        /// <summary>
        /// Appends a HTML-encoded string representing this instance to the <paramref name="stringBuilder"/> containing the Open Graph meta tags.
        /// </summary>
        /// <param name="stringBuilder">The string builder.</param>
        public override void ToString(StringBuilder stringBuilder)
        {
            base.ToString(stringBuilder);

            if (this.Actors != null)
            {
                foreach (OpenGraphActor actor in this.Actors)
                {
                    stringBuilder.AppendMetaPropertyContentIfNotNull("video:actor", actor.ActorUrl);
                    stringBuilder.AppendMetaPropertyContentIfNotNull("video:actor:role", actor.Role);
                }
            }

            stringBuilder.AppendMetaPropertyContentIfNotNull("video:director", this.DirectorUrls);
            stringBuilder.AppendMetaPropertyContentIfNotNull("video:writer", this.WriterUrls);
            stringBuilder.AppendMetaPropertyContentIfNotNull("video:duration", this.Duration);
            stringBuilder.AppendMetaPropertyContentIfNotNull("video:release_date", this.ReleaseDate);
            stringBuilder.AppendMetaPropertyContentIfNotNull("video:tag", this.Tags);
        }
    }
}
