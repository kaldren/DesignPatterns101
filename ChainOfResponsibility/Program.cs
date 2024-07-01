public class Document { }

public abstract class DocumentHandler
{
    public DocumentHandler _next;

    protected DocumentHandler(DocumentHandler next)
    {
        _next = next;
    }

    public void SetNextHandler(DocumentHandler next)
    {
        _next = next;
    }

    public abstract void HandleRequest(Document document);
}

public class GrammarCheckHandler : DocumentHandler
{
    public GrammarCheckHandler(DocumentHandler next) : base(next) { }

    public override void HandleRequest(Document document)
    {
        Console.WriteLine("Checking for grammar mistakes...");

        if (_next != null)
        {
            _next.HandleRequest(document);
        }
    }
}

public class GDPRComplianceCheckHandler : DocumentHandler
{
    public GDPRComplianceCheckHandler(DocumentHandler next) : base(next) { }

    public override void HandleRequest(Document document)
    {
        Console.WriteLine("Checking for GDPR compliance...");

        if (_next != null)
        {
            _next.HandleRequest(document);
        }
    }
}

public class CopyrightInfringementCheckHandler : DocumentHandler
{
    public CopyrightInfringementCheckHandler(DocumentHandler next) : base(next) { }

    public override void HandleRequest(Document document)
    {
        Console.WriteLine("Checking for copyright infrigement...");

        if (_next != null)
        {
            _next.HandleRequest(document);
        }
    }
}

public class SensitiveInformationCheckHandler : DocumentHandler
{
    public SensitiveInformationCheckHandler(DocumentHandler next) : base(next) { }

    public override void HandleRequest(Document document)
    {
        Console.WriteLine("Checking for sensitive information (passwords, certificates, etc.)...");

        if (_next != null)
        {
            _next.HandleRequest(document);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Document document = new Document();

        // Chain the handlers in the correct order
        DocumentHandler handlerChain = new GrammarCheckHandler(
            new GDPRComplianceCheckHandler(
                new CopyrightInfringementCheckHandler(
                    new SensitiveInformationCheckHandler(null))));

        // Start the processing with the first handler
        handlerChain.HandleRequest(document);
    }
}
