open chia.dotnet


let endpoint = Config.Open().GetEndpoint("full_node")
printfn "%s" endpoint.Uri.AbsoluteUri
let rpcClient = new HttpRpcClient(endpoint)

let fullNode = new FullNodeProxy(rpcClient, "unit_tests")
let state = fullNode.GetBlockchainState() |> Async.AwaitTask |> Async.RunSynchronously
let mempoolSize = state.MempoolSize
printfn "%A\n" state 
let json = Newtonsoft.Json.JsonConvert.SerializeObject(state.Peak)
printfn "%s" json