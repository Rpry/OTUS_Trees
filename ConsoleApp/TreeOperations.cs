namespace ConsoleApp;

public class TreeOperations
{
    public static TreeNode<string> SimpleTree()
    {
        var tree = new TreeNode<string>
        {
            Value = "Корень"
        };
        tree.Left = new TreeNode<string>
        {
            Value = "Левая дочка"
        };
        tree.Right = new TreeNode<string>
        {
            Value = "Правая дочка"
        };
        return tree;
    }
    
    public static void TraverseTree<T>(TreeNode<T> originNode)
    {
        Console.WriteLine("Traversing tree:");
        Traverse(originNode);
    }
    
    public static TreeNode<string> GenerateTree(int[] array)
    {
        var tree = new TreeNode<string>();
        foreach (var element in array)
        {
            //tree.AddNode(element);
        }

        return null;
    }

    public static void Traverse<T>(TreeNode<T> originNode)
    {
        if (originNode.Left != null)
        {
            Traverse(originNode.Left);
        }
        Process(originNode.Value);
        if (originNode.Right != null)
        {
            Traverse(originNode.Right);
        }
    }

    private static void Process<T>(T nodeValue)
    {
        //какая-то обработка
        Console.WriteLine(nodeValue);
    }

    public static void DeleteFromTree(TreeNode<int> root)
    {
        Console.WriteLine("input item to delete");
        while (true)
        {
            var s = Console.ReadLine();
            var d = int.Parse(s);
            if (d == 0)
            {
                break;
            }
            FindAndDeleteNode(root, d);
        }
    }

    public static TreeNode<int> InputTree()
    {
        TreeNode<int> root = null;
        while (true)
        {
            var s = Console.ReadLine();
            var d = int.Parse(s);
            if (d == 0)
            {
                break;
            }

            if (root == null)
            {
                root = new TreeNode<int>()
                {
                    Value = d
                };
            }
            else
            {
                AddNode(root, new TreeNode<int>()
                {
                    Value = d
                });
            }
        }

        return root;
    }

    public static void FindNumber(TreeNode<int> root)
    {
        Console.WriteLine("Enter number to find");
        while (true)
        {
            var s = Console.ReadLine();
            var d = int.Parse(s);
            if (d == 0)
            {
                break;
            }

            var (node, level) = FindNode(root, d, operationsCount: 0);
            if (node != null)
            {
                Console.WriteLine($"Found: {node.Value}; operations: {level}");
            }
            else
            {
                Console.WriteLine($"Node not found");
            }
        }
    }

    public static (TreeNode<int>, int) FindNode(TreeNode<int> root, int number, int operationsCount)
    {
        if (number < root.Value)
        {
            //Ищем в левом поддереве
            if (root.Left != null)
            {
                return FindNode(root.Left, number, operationsCount + 1);
            }
 
            return (null, -1);
        }
        if (number > root.Value)
        {
            //Ищем в правом поддереве
            if (root.Right != null)
            {
                return FindNode(root.Right, number, operationsCount + 1);
            }

            return (null, -1);
        }

        return (root, operationsCount + 1);
    }
    
    public static void AddNode(TreeNode<int> rootNode, TreeNode<int> nodeToAdd)
    {
        if (nodeToAdd.Value < rootNode.Value)
        {
            //Добавляемый меньше корневого?
            //идем в левое поддерево
            if (rootNode.Left != null)
            {
                AddNode(rootNode.Left, nodeToAdd);
            }
            else
            {
                rootNode.Left = nodeToAdd;
            }
        }
        else
        {
            //Добавляемый больше или равен корневому?
            //идем в правое поддерево
            if (rootNode.Right != null)
            {
                AddNode(rootNode.Right, nodeToAdd);
            }
            else
            {
                rootNode.Right = nodeToAdd;
            }
        }
    }
    
    private static int GetMinValue(TreeNode<int> node)
    {
 
        if(node.Left != null) {
            return GetMinValue(node.Left);
        }
        return node.Value;
    }
    
    public static TreeNode<int> FindAndDeleteNode(TreeNode<int> root, int value)
    {
        if (root == null) return root;
 
        if(value < root.Value) //удаляемое меньше текущего
        {
            root.Left = FindAndDeleteNode(root.Left, value);
        } 
        else if(value > root.Value) //удаляемое больше текущего
        {
            root.Right = FindAndDeleteNode(root.Right, value);
        }
        else //удаляемое равно текущему 
        {
            //текущий узел - листовой
            if(root.Left == null && root.Right == null) 
            {
                return null;
            }
            //текущий узел имеет только правый дочерний
            if(root.Left == null)
            {
                Console.WriteLine($"Удаление {value}");
                return root.Right;
            }
            //текущий узел имеет только левый дочерний
            if(root.Right == null)
            {
                Console.WriteLine($"Удаление {value}");
                return root.Left;
            }
            //текущий узел имеет два дочерних
            int minValue = GetMinValue(root.Right);
            root.Value = minValue;
            root.Right = FindAndDeleteNode(root.Right, minValue);
            Console.WriteLine($"Значение {value} заменено на {minValue}");
        }
 
        return root;
    }
}
