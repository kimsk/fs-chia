open chia.dotnet

let endpoint = Config.Open("/home/karlkim/.chia/testnet/config/config.yaml").GetEndpoint("full_node")
printfn "%s" endpoint.Uri.AbsoluteUri
let rpcClient = new HttpRpcClient(endpoint)

let fullNode = new FullNodeProxy(rpcClient, "unit_tests")
let state = fullNode.GetBlockchainState() |> Async.AwaitTask |> Async.RunSynchronously
let mempoolSize = state.MempoolSize
printfn "%A" state 