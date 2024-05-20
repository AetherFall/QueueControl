using Application.Interfaces;
using Domain.Interfaces;
using Shared.Models;

namespace Application.Services;

public class PrintDocumentService : IPrintDocumentService
    {
        private readonly IPrintDocumentRepository _printDocumentRepository;

        public PrintDocumentService(IPrintDocumentRepository printDocumentRepository)
        {
            _printDocumentRepository = printDocumentRepository;
        }

        public async Task<IEnumerable<PrintDocument>> GetAllAsync()
        {
            return await _printDocumentRepository.GetAllAsync();
        }

        public async Task<PrintDocument?> GetByIdAsync(int id)
        {
            return await _printDocumentRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(PrintDocument printDocument)
        {
            await _printDocumentRepository.AddAsync(printDocument);
        }

        public async Task UpdateAsync(int id, PrintDocument printDocumentDto)
        {
            var printDocument = await _printDocumentRepository.GetByIdAsync(id);
            if (printDocument != null)
            {
                printDocument.DocumentName = printDocumentDto.DocumentName;
                printDocument.DocumentPathReference = printDocumentDto.DocumentPathReference;
                printDocument.DocumentSQLQuery = printDocumentDto.DocumentSQLQuery;
                printDocument.IsActive = printDocumentDto.IsActive;
                printDocument.PrintTypeId = printDocumentDto.PrintTypeId;

                await _printDocumentRepository.UpdateAsync(printDocument);
            }
        }

        public async Task DeleteAsync(int id)
        {
            await _printDocumentRepository.DeleteAsync(id);
        }
    }