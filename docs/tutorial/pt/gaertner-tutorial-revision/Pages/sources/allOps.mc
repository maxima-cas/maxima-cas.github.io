/* --------------------------------------------------
 allOps(expession)
     answers a list with all operands in  expression.
     The list represents a set, no operand occurs more then once.

 allOpsPriv(expression, opList)
     The arguments are an expression and a list of
     operand names. The function answers a list that
     contains all elements of  opList and all operands
     in  expression. 
 ---------------------------------------------------*/
allOpsPriv(expression, opList) :=
 block ( [x, args, newList],
        if atom(expression)
           then opList
           else
             (x:    op(expression),
              args: args(expression),
              newList: if member (x, opList)
                          then opList
                          else cons(x, opList),
              for arg in args do
                newList: allOpsPriv(arg, newList),
              newList
             ) 
        )$

allOps(expression):=
 block( [ ],
        allOpsPriv (expression, [])
       )$