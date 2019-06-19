# QueryComponent(*TParameters*, *TQueryResult*) Interface
 

A component in a <a href="82639357-28f5-d7fe-833e-926791d1bac8">Query(TParameters, TQueryResult)</a>.

**Namespace:**&nbsp;<a href="2c7fd788-c68e-5cf6-959a-1767d64db41e">WeelinkIT.FluentSQL.Querying</a><br />**Assembly:**&nbsp;Weelink-IT.FluentSQL (in Weelink-IT.FluentSQL.dll) Version: 1.0.0

## Syntax

**C#**<br />
``` C#
public interface QueryComponent<TParameters, TQueryResult>
where TParameters : new()

```


#### Type Parameters
&nbsp;<dl><dt>TParameters</dt><dd>The parameters required for executing this <a href="82639357-28f5-d7fe-833e-926791d1bac8">Query(TParameters, TQueryResult)</a>.</dd><dt>TQueryResult</dt><dd>The result type of the <a href="82639357-28f5-d7fe-833e-926791d1bac8">Query(TParameters, TQueryResult)</a>.</dd></dl>&nbsp;
The QueryComponent(TParameters, TQueryResult) type exposes the following members.


## Properties
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="e0cc3af2-b1eb-43f8-17c1-0b8fcff219f1">QueryContext</a></td><td>
Return the underlying <a href="ab3b95a4-da50-b636-4e83-5f53a89483b3">QueryContext(TParameters, TQueryResult)</a>.</td></tr></table>&nbsp;
<a href="#querycomponent(*tparameters*,-*tqueryresult*)-interface">Back to Top</a>

## See Also


#### Reference
<a href="2c7fd788-c68e-5cf6-959a-1767d64db41e">WeelinkIT.FluentSQL.Querying Namespace</a><br />