using System.Text;
using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;
using UglyToad.PdfPig.DocumentLayoutAnalysis;
using UglyToad.PdfPig.DocumentLayoutAnalysis.PageSegmenter;

namespace ApplyBuddy.Server.Features.Documents.Services;

public class CvParser : ICvParser
{
    private readonly ILogger<CvParser> _logger;

    public CvParser(ILogger<CvParser> logger)
    {
        _logger = logger;
    }

    public string Parse(string documentPath)
    {
        var sb = new StringBuilder();
        var blocksToOutput = new List<string>();

        using (var document = PdfDocument.Open(documentPath))
        {
            for (var i = 0; i < document.NumberOfPages; i++)
            {
                var page = document.GetPage(i + 1);
                var words = page.GetWords();

                var blocks = DocstrumBoundingBoxes.Instance.GetBlocks(words);

                // foreach (var block in blocks)
                // {
                //     foreach (var textLine in  block.TextLines)
                //     {
                //         var cleanedLine = CleanText(textLine.Text);
                //         if (!string.IsNullOrWhiteSpace(cleanedLine))
                //         {
                //             
                //         }
                //     }
                // }

                foreach (var word in words)
                {
                    var cleanedWord = CleanText(word.Text);
                    if (!string.IsNullOrWhiteSpace(cleanedWord))
                    {
                        sb.Append(cleanedWord.ToLowerInvariant())
                            .Append(" ");
                    }
                }
            }
        }

        var parsedWords = sb.ToString();
        _logger.LogInformation(parsedWords);
        return parsedWords;
    }

    private string CleanText(string input)
    {
        var normalised = input.Normalize(NormalizationForm.FormC);
        return new string(normalised
            .Where(c =>
                !char.IsControl(c) &&
                c != '\u2022' &&
                c != '\u200B' &&
                c != '\u200C' &&
                c != '\u200D' &&
                char.GetUnicodeCategory(c) != System.Globalization.UnicodeCategory.OtherSymbol)
            .ToArray()).Trim();
    }
}