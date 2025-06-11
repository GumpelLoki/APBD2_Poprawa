using Kolos2Poprawa.Data;
using Kolos2Poprawa.DTOs;
using Kolos2Poprawa.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Kolos2Poprawa.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;

    public DbService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<CharacterItemsDto> GetCharacterItems(int id)
    {
        var items = await _context.Characters
            .Where(e => e.CharacterId == id)
            .Select(e => new CharacterItemsDto
            {
                FirstName = e.FirstName,
                LastName = e.LastName,
                CurrentWeight = e.CurrentWeight,
                MaxWeight = e.MaxWeight,
                BackpackItems = e.Backpacks.Select(b => new BackpackDto()
                {
                    ItemName = b.Item.Name,
                    ItemWeight = b.Item.Weight,
                    Amount = b.Amount
                }).ToList(),
                Titles = e.CharacterTitles.Select(t => new TitleDto()
                {
                    Title = t.Title.Name,
                    AcquiredAt = t.AcquiredAt
                }).ToList(),
            }).FirstOrDefaultAsync();
        if (items == null)
            throw new NotFoundException($"Character{id} not found");
        return items;
    }

    public async Task FillBackpack(List<int> ids, int id)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var character = await _context.Characters.FirstOrDefaultAsync(e => e.CharacterId == id);
            if (character == null)
                throw new NotFoundException($"Character{id} not found");
            var remainingweight = await _context.Characters.Select(e => e.MaxWeight-e.CurrentWeight).SumAsync();
            foreach (int idd in ids)
            {
                var item =  await _context.Items.FirstOrDefaultAsync(e => e.ItemId == idd);
                if (item == null)
                    throw new NotFoundException($"Item{id} not found");
            }
                
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}