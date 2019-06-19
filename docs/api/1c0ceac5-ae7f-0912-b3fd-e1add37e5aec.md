# WhereExtensions.Where(*TParameters*, *TQueryResult*) Method (QueryComponent(*TParameters*, *TQueryResult*), Expression(Func(*TParameters*, Boolean)))
 

Add a new `WHERE` to the <a href="82639357-28f5-d7fe-833e-926791d1bac8">Query(TParameters, TQueryResult)</a>.

**Namespace:**&nbsp;<a href="177c9a6d-318f-ac8a-07a6-73d6eee6ff0b">WeelinkIT.FluentSQL.Querying.Statements.Extensions</a><br />**Assembly:**&nbsp;Weelink-IT.FluentSQL (in Weelink-IT.FluentSQL.dll) Version: 1.0.0

## Syntax

**C#**<br />
``` C#
public static Where<TParameters, TQueryResult> Where<TParameters, TQueryResult>(
	this QueryComponent<TParameters, TQueryResult> queryComponent,
	Expression<Func<TParameters, bool>> expression
)
where TParameters : new()

```


#### Parameters
&nbsp;<dl><dt>queryComponent</dt><dd>Type: <a href="99a943bf-ed1c-c4ab-faea-abee3cf13828">WeelinkIT.FluentSQL.Querying.QueryComponent</a>(*TParameters*, *TQueryResult*)<br />The <a href="99a943bf-ed1c-c4ab-faea-abee3cf13828">QueryComponent(TParameters, TQueryResult)</a>.</dd><dt>expression</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/bb335710" target="_blank">System.Linq.Expressions.Expression</a>(<a href="http://msdn2.microsoft.com/en-us/library/bb549151" target="_blank">Func</a>(*TParameters*, <a href="http://msdn2.microsoft.com/en-us/library/a28wyd50" target="_blank">Boolean</a>))<br />The <a href="http://msdn2.microsoft.com/en-us/library/bb335710" target="_blank">Expression<Func<TTable, bool>></a> that indicates on which columns to join.</dd></dl>

#### Type Parameters
&nbsp;<dl><dt>TParameters</dt><dd>The parameters required for executing this <a href="82639357-28f5-d7fe-833e-926791d1bac8">Query(TParameters, TQueryResult)</a>.</dd><dt>TQueryResult</dt><dd>The result type of the <a href="82639357-28f5-d7fe-833e-926791d1bac8">Query(TParameters, TQueryResult)</a>.</dd></dl>

#### Return Value
Type: <a href="36a7454c-4550-b129-5cbf-e5e695cc1bb7">Where</a>(*TParameters*, *TQueryResult*)<br />The <a href="36a7454c-4550-b129-5cbf-e5e695cc1bb7">Where(TParameters, TQueryResult)</a>.

#### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type <a href="99a943bf-ed1c-c4ab-faea-abee3cf13828">QueryComponent</a>(*TParameters*, *TQueryResult*). When you use instance method syntax to call this method, omit the first parameter. For more information, see <a href="http://msdn.microsoft.com/en-us/library/bb384936.aspx">Extension Methods (Visual Basic)</a> or <a href="http://msdn.microsoft.com/en-us/library/bb383977.aspx">Extension Methods (C# Programming Guide)</a>.

## See Also


#### Reference
<a href="5d63a070-577c-2dc2-968f-fa1c7edf72c0">WhereExtensions Class</a><br /><a href="9e53d7ba-ed0d-1720-f9cf-e9c33d717b02">Where Overload</a><br /><a href="177c9a6d-318f-ac8a-07a6-73d6eee6ff0b">WeelinkIT.FluentSQL.Querying.Statements.Extensions Namespace</a><br />