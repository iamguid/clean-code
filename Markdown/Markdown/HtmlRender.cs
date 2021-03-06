using System;
using System.Text;

namespace Markdown
{
    public static class HtmlRender
    {
        public static string RenderDocument(Document document)
        {
            return RenderNode(document.RootNode);
        }

        private static string RenderNode(TreeNode treeNode)
        {
            var stringBuilder = new StringBuilder();

            foreach (var node in treeNode.Child)
            {
                switch (node.Type)
                {
                    case NodeType.Text:
                        var textNode = (TextNode) node;
                        stringBuilder.Append(RemoveBackslashes(textNode.Text));
                        break;
                    
                    case NodeType.DoubleUnderlineTag:
                        stringBuilder.Append($"<strong>{RenderNode(node)}</strong>");
                        break;
                    
                    case NodeType.SingleUnderlineTag:
                        stringBuilder.Append($"<em>{RenderNode(node)}</em>");
                        break;
                }
            }

            return stringBuilder.ToString();
        }

        private static string RemoveBackslashes(string str)
        {
            return str.Replace("\\", "");
        }
    }
}