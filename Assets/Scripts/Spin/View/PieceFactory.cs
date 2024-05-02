using Spin.Data;
using Spin.Manager;
using Spin.View.Piece;
using System.Collections.Generic;

namespace Spin.View
{
    public class PieceFactory:IPieceFactory
    {
        public void SetPieceData(List<WheelPiece> pieces, WheelData data, ISpriteAtlasManager spriteAtlasManager)
        {
            for (int i = 0; i < pieces.Count; i++)
            {
                pieces[i].SetPiece(data.Items[i].itemIcon, data.Items[i].itemValue, spriteAtlasManager);
            }
        }
        public void SetSinglePieceData(WheelPiece piece, WheelData.ItemData data,ISpriteAtlasManager spriteAtlasManager)
        {
            piece.SetPiece(data.itemIcon, data.itemValue, spriteAtlasManager);
        }
    }
    public interface IPieceFactory
    {
        void SetPieceData(List<WheelPiece> pieces, WheelData data, ISpriteAtlasManager spriteAtlasManager);
        void SetSinglePieceData(WheelPiece piece, WheelData.ItemData data, ISpriteAtlasManager spriteAtlasManager);
    }
}
