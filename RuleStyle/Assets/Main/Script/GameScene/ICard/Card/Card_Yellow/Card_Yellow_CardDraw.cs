
/// <summary>
/// 改変カードを参照する
/// </summary>
public class Card_Yellow_CardDraw : ICard
{
    public PlayerSessionData PlayerData { get; set; } = null;

    public float? ProbabilityNum => 25;
    Card_Pattern ICard.card_pattern => Card_Pattern.Yellow;

    /// <summary>
    /// カード名
    /// </summary>
    string ICard.CardName => "カードを引く";

    

    /// <summary>
    /// 
    /// </summary>
    void ICard.CardNum()
    {

    }
}
