# wth

## Abstract

A reimplementation of BSDgames' wtf acronym decoder in C#

Written in about 15 minutes

For those unfamiliar, the 'wtf' utility takes an acronym as input, such as "WTF", and returns an output attempting to decode the meaning of the input, such as "Where's the food"

The idea being to use it to decode 

## Usage

`wth [acronym]`

With [acronym] being the acronym you wish to decode

Example: `wth wth` returns `WTH \n What the hell`

## "Database" Structure

The entries in wth.txt are formatted according to the following structure:

```
Mock up:
ACRONYM. This is the definition of the acronym
Example:
WTH. What the hell
WTF. What the {Fuck, Frick}. Where's the food
```

1 Entry per line, Acronyms and descriptions are separated by `. ` (Space included), multiple definitions can be added for a single acronym by simply adding another `. ` and inserting another definition, Or by adding it on a new line.

Places where multiple words could fit (like "Oh my gosh" / "Oh my goodness") are noted like such: Oh my {gosh, goodness}.

## Todo

- [x] Upload to Github

- [x] Update wtf database to the wth 'standard'

- [ ] Adding more acronyms

- [x] Ignore / Filter out special characters from input

- [ ] Release executable

- [ ] Add binary to some repo?

- [x] Clean and refactor the code

- [ ] Optimise the code (Alot)

- [x] Refactor database parsing to allow duplicate entries
