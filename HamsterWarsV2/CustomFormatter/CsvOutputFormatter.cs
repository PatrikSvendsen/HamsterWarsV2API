using System.Text;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using Shared.DataTransferObjects.Match;

namespace HamsterWarsV2.CustomFormatter;

public class CsvOutputFormatter : TextOutputFormatter
{
    public CsvOutputFormatter()
    {
        SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv"));
        SupportedEncodings.Add(Encoding.UTF8);
        SupportedEncodings.Add(Encoding.Unicode);
    }
    protected override bool CanWriteType(Type? type)
    {
        if (typeof(MatchDto).IsAssignableFrom(type) ||
       typeof(IEnumerable<MatchDto>).IsAssignableFrom(type))
        {
            return base.CanWriteType(type);
        }
        return false;
    }

    public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext
   context, Encoding selectedEncoding)
    {
        var response = context.HttpContext.Response;
        var buffer = new StringBuilder();
        if (context.Object is IEnumerable<MatchDto>)
        {
            foreach (var match in (IEnumerable<MatchDto>)context.Object)
            {
                FormatCsv(buffer, match);
            }
        }
        else
        {
            FormatCsv(buffer, (MatchDto)context.Object);
        }

        await response.WriteAsync(buffer.ToString());
    }
    private static void FormatCsv(StringBuilder buffer, MatchDto match)
    {
        buffer.AppendLine($"MatchId:{match.Id},\"WinnerId:{match.WinnerId},\"LoserId:{match.LoserId}\"");
    }
}
