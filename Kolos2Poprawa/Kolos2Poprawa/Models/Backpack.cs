using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Kolos2Poprawa.Models;
[Table("Backpack")]
[PrimaryKey(nameof(ItemId),nameof(CharacterId))]
public class Backpack
{
    [ForeignKey(nameof(Item))] public int ItemId { get; set; }
    [ForeignKey(nameof(Character))]public int CharacterId { get; set; }
    public int Amount { get; set; }
    public Item Item { get; set; } = null!;
    public Character Character { get; set; } = null!;
}