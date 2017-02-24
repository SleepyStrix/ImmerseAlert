#[See videos and screenshots on Devpost!] (http://devpost.com/software/immersealert)

# ImmerseAlert
Smart-home safety software for gamers, mitigating the risks of immersive/VR gaming.

## Inspiration
Deeply immersive games are amazing for their ability to draw players into another world, something Virtual Reality is taking even further.
The downside to immersing your senses in a game is a serious lack of awareness of potential dangers in your surroundings.

## What it does
**ImmerseAlert** makes it easier to both immerse yourself in a game AND not be oblivious to **fires, carbon monoxide, and home invasions.**
This software links to a user's Nest Protect smoke/CO detectors and Nest Cam security cameras to aggressively alert users to danger.
**IA** forces an alert to the front through even full-screen applications in combination with an audible alarm forced to max volume to jolt players out of their games and into reality as quickly as possible.
Different alert messages are displayed depending on the cause.

## How I built it
The core software is a multi-threaded Windows Forms application written in C#.
Nest integration is accomplished though the Nest REST API.
Alerts are forced on top of full-screen applications on an interval to ensure alerts are not missed or covered by games in life-threatening situations.
GUI was intentionally left a bit ugly to avoid confusion with a video game GUI.
Audio was created with Linux Multimedia Studio.

## Challenges I ran into
Nest's sometimes inconsistent and confusing developer documentation was probably the greatest challenge.
The headache from hearing my incredibly annoying alarm for several hours didn't help.
Information about forcing windows above everything was often a dead-end as, in most other cases, that would be a terrible design and is frowned upon.
Finding a balance between aggressively pushing the alert, preventing accidental alert cancellation, and being able to cancel alerts once acknowledged was also a challenge..

## Accomplishments that I'm proud of
Creating something that could save lives right now if someone actually used it is what I'm most proud of.
This is also the most complete project I've put together at a hackathon so far.

## What I learned
Far more about HTTP redirection than I ever wanted too (thanks Nest API).
Advanced Windows Forms development.
Designing for intentional unpleasantness and annoyance where necessary.

## What's next for ImmerseAlert
Everything I wrote for **ImmerseAlert** is open-source, free, and will stay that way.
_Life-saving-anything should be free._
I'd like someone to fork it as I won't normally have much time for this in the foreseeable future

## Forking
I've included keys/urls for an existing Nest product in NestApi.config, but you are encouraged to create your own product at [developers.nest.com](http://developers.nest.com/) and use your product's keys/urls instead if forking.