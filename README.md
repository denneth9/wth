# wth

## Abstract

 A reimplementation of BSDgames' wtf acronym decoder in C#

Written in about 15 minutes

## Usage

wth <acronym>

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

1 Entry per line, Acronyms and descriptions are separated by `. ` (Space included), multiple definitions can be added for a single acronym by simply adding another `. ` and inserting another definition.

## Todo

- [x] Upload to Github

- [ ] Update wtf database to the wth 'standard'

- [ ] Adding more acronyms

- [ ] Release executable

- [ ] Add to some repo?

- [ ] Clean and refactor the code

- [ ] Optimise the code (Alot)
