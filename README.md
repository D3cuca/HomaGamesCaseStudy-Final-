# HomaGamesCaseStudy--Final-
 Prototype for a mobile game runner

Thank you for playing and reviewing "Run Patrick!"
I'm going to explain a few things.

1)I wanted to integrate 2 aspects that I feel are satisfying in the gameplay.
-Scrolling (since we've been programmed to love to do that all day through social media)
-A counter (humans like to see numbers go up)
That's why I merged them toghether to make the "Speed build up system".

2)The model I used is not for commercial purposes but, the player model is completly independent to the movement, input
etc... That's because I wanted to be possible to change models easly and put the marketable theme as the player itself!
With this architecture, it's really easy to change the character played by the player and for the 3D models, we
only need:
-A model animation of the character running
-A model animation of the character dancing
-A model animation of the character laying back

3)I like to structure my projects as bits that work relatively well independently. A lot of this project follows
that pilosophy. But the most important parts are:
-The InputController (that registers the input on the touch screen)
-The MovementController ( that can be applied to ani runner game with 3 positions left/ center/ right)
-The ObjectSpawner (that spawns objects randomly depending on the objects of the available pool)

But my favourite (which I use in almost any project I make) is the SignalSender and SignalReceiver
The way it works is this:
SignalSender is a scriptable object (not serialized) asset. That means that we can create as many as we want
as simple as creating a new material, script or anything in the Unity asset menu. When the signal is raised,
it will go through all of its listeners (backwards in order to avoid a null reference error in case a SignalReceiver
disapears during the iteration) and raise the signal when necessary.

The SignalReceiver will listen to that created signal asset and register itself (when enabled) in the signal
asset list of listeners. Then when the signal is raised, it will simply invoke an event.

An example of this is for any game where we have a life.

-Step1 : Create a Signal "HurtSignal" that will be dragged and dropped in any object script that should do damage at one point.
-Step2 : Raise the signal "HurtSignal" when any of those objects has to do damage.
-Step3 : The player will have a SignalReceiver that will listen to "HurtSignal" and invoke any event that is needed.
Lower health, play damage sound, play an animation or anything.

And that's it! The great advantage of this is that is modulable in both ways.
-If you create a new enemy or object that can cause damage just tell it to raise the "HurtSignal"! The receiver is already 
listening.
-If you create a new object that will react to "HurtSignal", it is already registered as a listener.

I'd be glad to explain how I implemented it in this project because I think it's something very useful.

Thank you for this opportunity and I hope we'll be discussing soon.
