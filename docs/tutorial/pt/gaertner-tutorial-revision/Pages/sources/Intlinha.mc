/* --------------------------------------------------
Calcula a integral de linha de fn ao longo do caminho "caminho"
para valores parame'tricos de p0 a p1.
fn   e'uma expressa~o,
caminho e'uma lista de duas ou tre^s equac,o~es, cada uma
     com sua coordenada. O lado esquerdo das equac,o~oes
     e' o nome da coordenada, o lado direito
     e' alguma expressa~o no param (para^metro)m

 ---------------------------------------------------*/
Integrallinha(fn, caminho, param, p0, p1) :=
 block ( [substitutedFn, x, xx],
         substitutedFn: sublis(path, fn),
         x : ev (substitutedFn, diff),
         xx: subst(1, Diff(param), x),
         Integrate(xx, param, p0, p1) 
       )$

