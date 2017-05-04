# Lith.DocStore
A document database in the most literal case.

This document storage could be used to create quick prototypes without the need of connecting to an actual database.
Lith.DocStore provides interfaces that allow you to create physical data files which can be JSON, XML or anything you can serialize.

The idea behind this is that you can run unit tests against models and logic without commiting to a database or having a connection.
