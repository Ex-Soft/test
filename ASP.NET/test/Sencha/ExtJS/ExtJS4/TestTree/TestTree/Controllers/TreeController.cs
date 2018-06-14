using System.Collections.Generic;
using System.Web.Http;
using TestTree.Models;

namespace TestTree.Controllers
{
    public class TreeController : ApiController
    {
        [HttpGet]
        public TreeResponse Nodes([FromUri] TreeRequest request)
        {
            return new TreeResponse
            {
                children = new List<TreeNode> {
                    new TreeNode { id = 1, parentId = request.node, text = "Folder# 1", leaf = false, cls = "folder",
                        children = new List<TreeNode> {
                            new TreeNode { id = 3, parentId = 1, text = "File# 1.1", leaf = true, cls = "file" },
                            new TreeNode { id = 4, parentId = 1, text = "File# 1.2", leaf = true, cls = "file" },
                        }
                    },
                    new TreeNode { id = 2, parentId = request.node, text = "Folder# 2", leaf = false, cls = "folder",
                        children = new List<TreeNode> {
                            new TreeNode { id = 5, parentId = 2, text = "File# 2.1", leaf = true, cls = "file" },
                            new TreeNode { id = 6, parentId = 2, text = "File# 2.2", leaf = true, cls = "file" },
                        }
                    },
                }
            };
        }
    }
}
