//Apache2, 2012, Hernan J. González, (https://github.com/leonbloy)
//Apache2, 2017, WinterDev

using System;


namespace Hjg.Pngcs.Chunks
{
    /// <summary>
    /// Match if have same Chunk Id
    /// </summary>
    internal class ChunkPredicateId : ChunkPredicate
    {
        private readonly string id;
        public ChunkPredicateId(String id)
        {
            this.id = id;
        }
        public bool Matches(PngChunk c)
        {
            return c.Id.Equals(id);
        }
    }
}
