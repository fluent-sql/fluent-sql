# LimitExtensions.Limit(*TParameters*, *TQueryResult*) Method 
 

Limits the number of results.

**Namespace:**&nbsp;<a href="177c9a6d-318f-ac8a-07a6-73d6eee6ff0b">WeelinkIT.FluentSQL.Querying.Statements.Extensions</a><br />**Assembly:**&nbsp;Weelink-IT.FluentSQL (in Weelink-IT.FluentSQL.dll) Version: 1.0.0

## Syntax

**C#**<br />
``` C#
public static Limit<TParameters, TQueryResult> Limit<TParameters, TQueryResult>(
	this QueryComponent<TParameters, TQueryResult> queryComponent,
	int limit
)
where TParameters : new()

```


#### Parameters
&nbsp;<dl><dt>queryComponent</dt><dd>Type: <a href="99a943bf-ed1c-c4ab-faea-abee3cf13828">WeelinkIT.FluentSQL.Querying.QueryComponent</a>(*TParameters*, *TQueryResult*)<br />\[Missing <param name="queryComponent"/> documentation for "M:WeelinkIT.FluentSQL.Querying.Statements.Extensions.LimitExtensions.Limit``2(WeelinkIT.FluentSQL.Querying.QueryComponent{``0,``1},System.Int32)"\]</dd><dt>limit</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/td2s409d" target="_blank">System.Int32</a><br />\[Missing <param name="limit"/> documentation for "M:WeelinkIT.FluentSQL.Querying.Statements.Extensions.LimitExtensions.Limit``2(WeelinkIT.FluentSQL.Querying.QueryComponent{``0,``1},System.Int32)"\]</dd></dl>

#### Type Parameters
&nbsp;<dl><dt>TParameters</dt><dd>The parameters required for executing this <a href="82639357-28f5-d7fe-833e-926791d1bac8">Query(TParameters, TQueryResult)</a>.</dd><dt>TQueryResult</dt><dd>The result type of the <a href="82639357-28f5-d7fe-833e-926791d1bac8">Query(TParameters, TQueryResult)</a>.</dd></dl>

#### Return Value
Type: <a href="4e5ca608-27de-25c7-632a-41cb1a7a6ac7">Limit</a>(*TParameters*, *TQueryResult*)<br />The <a href="4e5ca608-27de-25c7-632a-41cb1a7a6ac7">Limit(TParameters, TQueryResult)</a>.

#### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type <a href="99a943bf-ed1c-c4ab-faea-abee3cf13828">QueryComponent</a>(*TParameters*, *TQueryResult*). When you use instance method syntax to call this method, omit the first parameter. For more information, see <a href="http://msdn.microsoft.com/en-us/library/bb384936.aspx">Extension Methods (Visual Basic)</a> or <a href="http://msdn.microsoft.com/en-us/library/bb383977.aspx">Extension Methods (C# Programming Guide)</a>.

## See Also


#### Reference
<a href="b279972f-4586-f168-3a79-1d3cf55b0768">LimitExtensions Class</a><br /><a href="177c9a6d-318f-ac8a-07a6-73d6eee6ff0b">WeelinkIT.FluentSQL.Querying.Statements.Extensions Namespace</a><br />