var e;

function Circle(radius)
{
  this.radius = radius;
  e=(this instanceof FullCircle);
}

Circle.prototype.area = function()
{
  e=(this instanceof FullCircle);
  return Math.PI * this.radius * this.radius;
}

function FullCircle(x, y, radius)
{
  this.x = x;
  this.y = y;
  this.radius = radius;
  this.mm=M();
  e=(this instanceof FullCircle);
  WScript.Echo((this instanceof FullCircle)+"^");
}

function M()
{
  WScript.Echo((this instanceof Object)+"*");
}

FullCircle.prototype = Circle.prototype;

var myCircle = new FullCircle(0, 0, 1);
//var myM = new M();
WScript.Echo(e +"|");
